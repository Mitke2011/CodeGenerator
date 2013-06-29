using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace TypeLib
{
    [System.SerializableAttribute()]
    public class PropertyDefinition
    {
        #region Fields
        private string ClassnameNameField;

        private string compositeTypeNameField;

        private string propertyNameField;

        private bool isID;


        private PropertyType propTypeField;


        private DataType dataTypeField;
        #endregion

        #region Properties
        public string ClassName
        {
            get
            {
                return this.ClassnameNameField;
            }
            set
            {
                this.ClassnameNameField = value;
            }
        }

        public string CompositeTypeName
        {
            get
            {
                return this.compositeTypeNameField;
            }
            set
            {
                this.compositeTypeNameField = value;
            }
        }

        public bool IsID
        {
            get { return isID; }
            set { isID = value; }
        }

        public string PropertyName
        {
            get
            {
                return this.propertyNameField;
            }
            set
            {
                this.propertyNameField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("PropType")]
        public PropertyType PropType
        {
            get
            {
                return this.propTypeField;
            }
            set
            {
                this.propTypeField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("DataType")]
        public DataType PropDataType
        {
            get
            {
                return this.dataTypeField;
            }
            set
            {
                this.dataTypeField = value;
            }
        }
        #endregion

    }

    [System.SerializableAttribute()]
    public enum PropertyType
    {

        Simple,

        Composite,

        ListSimple,

        ListComposites,
    }


    [System.SerializableAttribute()]
    public enum DataType
    {

        String,

        Boolean,

        Int16,

        Int32,

        Int64,

        DateTime,

        Single,

        Double,

        Byte,

        Object,
        //java specific types

        Integer,

        Long,

        Date
    }

}
