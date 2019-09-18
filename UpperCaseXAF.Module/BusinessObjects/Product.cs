using System;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System.ComponentModel;

namespace UpperCaseXAF.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty("ProductNumber")]
    public class Product : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Product(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        // Fields...
        private DateTime _time;
        private Client _client;
        private string _productNumber;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ProductNumber
        {
            get
            {
                return _productNumber;
            }
            set
            {
                SetPropertyValue("ProductNumber", ref _productNumber, value);
            }
        }


        public Client Client
        {
            get
            {
                return _client;
            }
            set
            {
                SetPropertyValue("Client", ref _client, value);
            }
        }


        public DateTime Time
        {
            get
            {
                return _time;
            }
            set
            {
                SetPropertyValue("Time", ref _time, value);
            }
        }



    }
}