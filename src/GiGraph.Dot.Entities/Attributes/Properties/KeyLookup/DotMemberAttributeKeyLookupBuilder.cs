using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Properties.KeyLookup
{
    /// <summary>
    ///     Builds a lookup for properties and property accessors.
    /// </summary>
    /// <typeparam name="TEntityAttributes">
    ///     The entity attributes type.
    /// </typeparam>
    /// <typeparam name="TIEntityAttributeProperties">
    ///     The interface that exposes entity-specific attributes of the <typeparamref name="TEntityAttributes" /> type.
    /// </typeparam>
    public class DotMemberAttributeKeyLookupBuilder<TEntityAttributes, TIEntityAttributeProperties>
        where TEntityAttributes : DotEntityAttributes, TIEntityAttributeProperties
    {
        /// <summary>
        ///     Builds lazily a lookup for properties and property accessors.
        /// </summary>
        /// <param name="readOnly">
        ///     Determines whether the built lookup should be read only.
        /// </param>
        public Lazy<DotMemberAttributeKeyLookup> BuildLazy(bool readOnly = true)
        {
            return new Lazy<DotMemberAttributeKeyLookup>(() => Build(readOnly));
        }

        /// <summary>
        ///     Builds a lookup for properties and property accessors.
        /// </summary>
        /// <param name="readOnly">
        ///     Determines whether the built lookup should be read only.
        /// </param>
        public DotMemberAttributeKeyLookup Build(bool readOnly = true)
        {
            var result = new DotMemberAttributeKeyLookup();

            var entityAttributePropertiesInterfaceTypes = typeof(TIEntityAttributeProperties).GetInterfaces()
               .Concat(new[] { typeof(TIEntityAttributeProperties) });

            foreach (var interfaceType in entityAttributePropertiesInterfaceTypes)
            {
                UpdateByInterfaceMembers(result, interfaceType);
            }

            return readOnly ? result.ToReadOnly() : result;
        }

        protected void UpdateByInterfaceMembers(DotMemberAttributeKeyLookup output, Type entityAttributePropertiesInterfaceType)
        {
            var interfaceProperties = entityAttributePropertiesInterfaceType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var interfaceMap = typeof(TEntityAttributes).GetInterfaceMap(entityAttributePropertiesInterfaceType);

            // build a temporary lookup for all types the implemented properties are declared by
            var tempLookup = BuildWithDeclaredPropertyAccessorsOf(
                interfaceMap.TargetMethods.Select(accessor => accessor.DeclaringType)
            );

            // based on the previously created lookup, include base definitions of all implemented property accessors
            for (var index = 0; index < interfaceMap.TargetMethods.Length; index++)
            {
                var interfaceMethod = interfaceMap.InterfaceMethods[index];
                var targetMethod = interfaceMap.TargetMethods[index];

                var key = tempLookup.GetPropertyAccessorKey(targetMethod);
                output.SetPropertyAccessorKey(targetMethod, key);

                tempLookup.SetPropertyAccessorKey(interfaceMethod, key);
            }

            // include interface properties
            foreach (var interfaceProperty in interfaceProperties)
            {
                var interfacePropertyAccessor = interfaceProperty.GetMethod ?? interfaceProperty.SetMethod;
                var key = tempLookup.GetPropertyAccessorKey(interfacePropertyAccessor);
                output.SetPropertyKey(interfaceProperty, key);
            }
        }

        protected virtual DotMemberAttributeKeyLookup BuildWithDeclaredPropertyAccessorsOf(IEnumerable<Type> entityAttributesTypes)
        {
            // don't use the common base property as the lookup key because when overridden, the descendant property may have a different
            // attribute key assigned, in which case it should become the final attribute key to use for the property
            // (if a common base was used, properties with the same ancestor would overwrite one another in the lookup
            // with the last one enforcing its attribute key as the final key)
            var result = new DotMemberAttributeKeyLookup(useCommonBaseAsLookupKey: false);

            foreach (var entityAttributesType in entityAttributesTypes.Distinct())
            {
                UpdateWithDeclaredPropertyAccessorsOf(result, entityAttributesType);
            }

            return result;
        }

        protected void UpdateWithDeclaredPropertyAccessorsOf(DotMemberAttributeKeyLookup lookup, Type entityAttributesType)
        {
            var properties = entityAttributesType.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var property in properties)
            {
                if (property.GetCustomAttribute<DotAttributeKeyAttribute>() is not { } attribute)
                {
                    continue;
                }

                if (property.GetMethod is { } getter)
                {
                    lookup.SetPropertyAccessorKey(getter, attribute.Key);
                }

                if (property.SetMethod is { } setter)
                {
                    lookup.SetPropertyAccessorKey(setter, attribute.Key);
                }
            }
        }
    }
}