﻿using System.Collections.Generic;

namespace TypeLib
{
    using System.Xml.Serialization;
    [System.SerializableAttribute()]

    public partial class ObjectDefinition
    {
        private string classNameField;

        private string classNamespaceField;

        private List<PropertyDefinition> propertyField;

        public PropertyDefinition IDproperty()
        {
            PropertyDefinition IDprop = null;
            foreach (PropertyDefinition prop in propertyField)
            {
                if (prop.IsID)
                {
                    IDprop = prop;
                }
            }
            return IDprop;
        }

        public string ClassName
        {
            get
            {
                return this.classNameField;
            }
            set
            {
                this.classNameField = value;
            }
        }

        public string ClassNamespace
        {
            get
            {
                return this.classNamespaceField;
            }
            set
            {
                this.classNamespaceField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("Property")]
        public List<PropertyDefinition> Property
        {
            get
            {
                return this.propertyField;
            }
            set
            {
                this.propertyField = value;
            }
        }
    }

    //[System.SerializableAttribute()]
    //public class PropertyDefinition
    //{
    //    #region Fields
    //    private string ClassnameNameField;

    //    private string compositeTypeNameField;

    //    private string propertyNameField;

    //    private bool isID;

         
    //    private PropertyType propTypeField;

        
    //    private DataType dataTypeField;
    //    #endregion

    //    #region Properties
    //    public string ClassName
    //    {
    //        get
    //        {
    //            return this.ClassnameNameField;
    //        }
    //        set
    //        {
    //            this.ClassnameNameField = value;
    //        }
    //    }

    //    public string CompositeTypeName
    //    {
    //        get
    //        {
    //            return this.compositeTypeNameField;
    //        }
    //        set
    //        {
    //            this.compositeTypeNameField = value;
    //        }
    //    }

    //    public bool IsID
    //    {
    //        get { return isID; }
    //        set { isID = value; }
    //    }

    //    public string PropertyName
    //    {
    //        get
    //        {
    //            return this.propertyNameField;
    //        }
    //        set
    //        {
    //            this.propertyNameField = value;
    //        }
    //    }

    //    [System.Xml.Serialization.XmlElementAttribute("PropType")]
    //    public PropertyType PropType
    //    {
    //        get
    //        {
    //            return this.propTypeField;
    //        }
    //        set
    //        {
    //            this.propTypeField = value;
    //        }
    //    }

    //    [System.Xml.Serialization.XmlElementAttribute("DataType")]
    //    public DataType PropDataType
    //    {
    //        get
    //        {
    //            return this.dataTypeField;
    //        }
    //        set
    //        {
    //            this.dataTypeField = value;
    //        }
    //    }
    //    #endregion

    //}

    //[System.SerializableAttribute()]
    //public enum PropertyType
    //{

    //    Simple,

    //    Composite,

    //    ListSimple,

    //    ListComposites,
    //}


    //[System.SerializableAttribute()]
    //public enum DataType
    //{

    //    String,

    //    Boolean,

    //    Int16,

    //    Int32,

    //    Int64,

    //    DateTime,

    //    Single,

    //    Double,

    //    Byte,

    //    Object,
    //    //java specific types

    //    Integer,

    //    Long,

    //    Date
    //}
    
    //[System.SerializableAttribute()]
    //public class PropertyDefinition
    //{

    //    private string ClassnameNameField;

    //    private string compositeTypeNameField;

    //    private string propertyNameField;

    //    private bool isID;

    //    private PropertyType propTypeField;

    //    private DataType atomicTypeField;


    //    public string ClassName
    //    {
    //        get
    //        {
    //            return this.ClassnameNameField;
    //        }
    //        set
    //        {
    //            this.ClassnameNameField = value;
    //        }
    //    }

    //    public string CompositeTypeName
    //    {
    //        get
    //        {
    //            return this.compositeTypeNameField;
    //        }
    //        set
    //        {
    //            this.compositeTypeNameField = value;
    //        }
    //    }

    //    public bool IsID
    //    {
    //        get { return isID; }
    //        set { isID = value; }
    //    }

    //    public string PropertyName
    //    {
    //        get
    //        {
    //            return this.propertyNameField;
    //        }
    //        set
    //        {
    //            this.propertyNameField = value;
    //        }
    //    }

    //    public PropertyType PropType
    //    {
    //        get
    //        {
    //            return this.propTypeField;
    //        }
    //        set
    //        {
    //            this.propTypeField = value;
    //        }
    //    }

    //    public DataType AtomicType
    //    {
    //        get
    //        {
    //            return this.atomicTypeField;
    //        }
    //        set
    //        {
    //            this.atomicTypeField = value;
    //        }
    //    }

    //}

    //[System.SerializableAttribute()]
    //public enum PropertyType
    //{

    //    Atom,

    //    Composite,

    //    ListAtoms,

    //    ListComposites,
    //}

    
    //[System.SerializableAttribute()]
    //public enum DataType
    //{

    //    String,

    //    Boolean,

    //    Int16,

    //    Int32,

    //    Int64,

    //    DateTime,

    //    Single,

    //    Double,

    //    Byte,

    //    Object,
    //}
}
