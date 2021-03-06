//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PebbleCode.Framework.IoC
{
    
    
    /// <summary>
    /// The IoCKernelConfiguration Configuration Section.
    /// </summary>
    public partial class IoCKernelConfiguration : global::System.Configuration.ConfigurationSection
    {
        
        #region Singleton Instance
        /// <summary>
        /// The XML name of the IoCKernelConfiguration Configuration Section.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string IoCKernelConfigurationSectionName = "ioCKernelConfiguration";
        
        /// <summary>
        /// Gets the IoCKernelConfiguration instance.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public static global::PebbleCode.Framework.IoC.IoCKernelConfiguration Instance
        {
            get
            {
                return ((global::PebbleCode.Framework.IoC.IoCKernelConfiguration)(global::System.Configuration.ConfigurationManager.GetSection(global::PebbleCode.Framework.IoC.IoCKernelConfiguration.IoCKernelConfigurationSectionName)));
            }
        }
        #endregion
        
        #region Xmlns Property
        /// <summary>
        /// The XML name of the <see cref="Xmlns"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string XmlnsPropertyName = "xmlns";
        
        /// <summary>
        /// Gets the XML namespace of this Configuration Section.
        /// </summary>
        /// <remarks>
        /// This property makes sure that if the configuration file contains the XML namespace,
        /// the parser doesn't throw an exception because it encounters the unknown "xmlns" attribute.
        /// </remarks>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::PebbleCode.Framework.IoC.IoCKernelConfiguration.XmlnsPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public string Xmlns
        {
            get
            {
                return ((string)(base[global::PebbleCode.Framework.IoC.IoCKernelConfiguration.XmlnsPropertyName]));
            }
        }
        #endregion
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region BindingAssemblys Property
        /// <summary>
        /// The XML name of the <see cref="BindingAssemblys"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string BindingAssemblysPropertyName = "bindingAssemblys";
        
        /// <summary>
        /// Gets or sets the BindingAssemblys.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        [global::System.ComponentModel.DescriptionAttribute("The BindingAssemblys.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::PebbleCode.Framework.IoC.IoCKernelConfiguration.BindingAssemblysPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public global::PebbleCode.Framework.IoC.BindingAssemblys BindingAssemblys
        {
            get
            {
                return ((global::PebbleCode.Framework.IoC.BindingAssemblys)(base[global::PebbleCode.Framework.IoC.IoCKernelConfiguration.BindingAssemblysPropertyName]));
            }
            set
            {
                base[global::PebbleCode.Framework.IoC.IoCKernelConfiguration.BindingAssemblysPropertyName] = value;
            }
        }
        #endregion
    }
}
namespace PebbleCode.Framework.IoC
{
    
    
    /// <summary>
    /// A collection of BindingAssembly instances.
    /// </summary>
    [global::System.Configuration.ConfigurationCollectionAttribute(typeof(global::PebbleCode.Framework.IoC.BindingAssembly), CollectionType=global::System.Configuration.ConfigurationElementCollectionType.BasicMapAlternate, AddItemName=global::PebbleCode.Framework.IoC.BindingAssemblys.BindingAssemblyPropertyName)]
    public partial class BindingAssemblys : global::System.Configuration.ConfigurationElementCollection
    {
        
        #region Constants
        /// <summary>
        /// The XML name of the individual <see cref="global::PebbleCode.Framework.IoC.BindingAssembly"/> instances in this collection.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string BindingAssemblyPropertyName = "assembly";
        #endregion
        
        #region Overrides
        /// <summary>
        /// Gets the type of the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <returns>The <see cref="global::System.Configuration.ConfigurationElementCollectionType"/> of this collection.</returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public override global::System.Configuration.ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return global::System.Configuration.ConfigurationElementCollectionType.BasicMapAlternate;
            }
        }
        
        /// <summary>
        /// Gets the name used to identify this collection of elements
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        protected override string ElementName
        {
            get
            {
                return global::PebbleCode.Framework.IoC.BindingAssemblys.BindingAssemblyPropertyName;
            }
        }
        
        /// <summary>
        /// Indicates whether the specified <see cref="global::System.Configuration.ConfigurationElement"/> exists in the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="elementName">The name of the element to verify.</param>
        /// <returns>
        /// <see langword="true"/> if the element exists in the collection; otherwise, <see langword="false"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        protected override bool IsElementName(string elementName)
        {
            return (elementName == global::PebbleCode.Framework.IoC.BindingAssemblys.BindingAssemblyPropertyName);
        }
        
        /// <summary>
        /// Gets the element key for the specified configuration element.
        /// </summary>
        /// <param name="element">The <see cref="global::System.Configuration.ConfigurationElement"/> to return the key for.</param>
        /// <returns>
        /// An <see cref="object"/> that acts as the key for the specified <see cref="global::System.Configuration.ConfigurationElement"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        protected override object GetElementKey(global::System.Configuration.ConfigurationElement element)
        {
            return ((global::PebbleCode.Framework.IoC.BindingAssembly)(element)).Assembly;
        }
        
        /// <summary>
        /// Creates a new <see cref="global::PebbleCode.Framework.IoC.BindingAssembly"/>.
        /// </summary>
        /// <returns>
        /// A new <see cref="global::PebbleCode.Framework.IoC.BindingAssembly"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        protected override global::System.Configuration.ConfigurationElement CreateNewElement()
        {
            return new global::PebbleCode.Framework.IoC.BindingAssembly();
        }
        #endregion
        
        #region Indexer
        /// <summary>
        /// Gets the <see cref="global::PebbleCode.Framework.IoC.BindingAssembly"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the <see cref="global::PebbleCode.Framework.IoC.BindingAssembly"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public global::PebbleCode.Framework.IoC.BindingAssembly this[int index]
        {
            get
            {
                return ((global::PebbleCode.Framework.IoC.BindingAssembly)(base.BaseGet(index)));
            }
        }
        
        /// <summary>
        /// Gets the <see cref="global::PebbleCode.Framework.IoC.BindingAssembly"/> with the specified key.
        /// </summary>
        /// <param name="assembly">The key of the <see cref="global::PebbleCode.Framework.IoC.BindingAssembly"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public global::PebbleCode.Framework.IoC.BindingAssembly this[object assembly]
        {
            get
            {
                return ((global::PebbleCode.Framework.IoC.BindingAssembly)(base.BaseGet(assembly)));
            }
        }
        #endregion
        
        #region Add
        /// <summary>
        /// Adds the specified <see cref="global::PebbleCode.Framework.IoC.BindingAssembly"/> to the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="assembly">The <see cref="global::PebbleCode.Framework.IoC.BindingAssembly"/> to add.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public void Add(global::PebbleCode.Framework.IoC.BindingAssembly assembly)
        {
            base.BaseAdd(assembly);
        }
        #endregion
        
        #region Remove
        /// <summary>
        /// Removes the specified <see cref="global::PebbleCode.Framework.IoC.BindingAssembly"/> from the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="assembly">The <see cref="global::PebbleCode.Framework.IoC.BindingAssembly"/> to remove.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public void Remove(global::PebbleCode.Framework.IoC.BindingAssembly assembly)
        {
            base.BaseRemove(this.GetElementKey(assembly));
        }
        #endregion
        
        #region GetItem
        /// <summary>
        /// Gets the <see cref="global::PebbleCode.Framework.IoC.BindingAssembly"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the <see cref="global::PebbleCode.Framework.IoC.BindingAssembly"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public global::PebbleCode.Framework.IoC.BindingAssembly GetItemAt(int index)
        {
            return ((global::PebbleCode.Framework.IoC.BindingAssembly)(base.BaseGet(index)));
        }
        
        /// <summary>
        /// Gets the <see cref="global::PebbleCode.Framework.IoC.BindingAssembly"/> with the specified key.
        /// </summary>
        /// <param name="assembly">The key of the <see cref="global::PebbleCode.Framework.IoC.BindingAssembly"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public global::PebbleCode.Framework.IoC.BindingAssembly GetItemByKey(string assembly)
        {
            return ((global::PebbleCode.Framework.IoC.BindingAssembly)(base.BaseGet(((object)(assembly)))));
        }
        #endregion
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
    }
}
namespace PebbleCode.Framework.IoC
{
    
    
    /// <summary>
    /// The BindingAssembly Configuration Element.
    /// </summary>
    public partial class BindingAssembly : global::System.Configuration.ConfigurationElement
    {
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region Assembly Property
        /// <summary>
        /// The XML name of the <see cref="Assembly"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string AssemblyPropertyName = "assembly";
        
        /// <summary>
        /// Gets or sets the Assembly.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        [global::System.ComponentModel.DescriptionAttribute("The Assembly.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::PebbleCode.Framework.IoC.BindingAssembly.AssemblyPropertyName, IsRequired=true, IsKey=true, IsDefaultCollection=false)]
        public string Assembly
        {
            get
            {
                return ((string)(base[global::PebbleCode.Framework.IoC.BindingAssembly.AssemblyPropertyName]));
            }
            set
            {
                base[global::PebbleCode.Framework.IoC.BindingAssembly.AssemblyPropertyName] = value;
            }
        }
        #endregion
    }
}
