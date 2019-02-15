using System.Xml.Serialization;
using System.Collections.Generic;

namespace XML
{
    [XmlRoot(ElementName = "script")]
    public class Script
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "charset")]
        public string Charset { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "currency")]
    public class Currency
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "rate")]
        public string Rate { get; set; }
    }

    [XmlRoot(ElementName = "currencies")]
    public class Currencies
    {
        [XmlElement(ElementName = "currency")]
        public Currency Currency { get; set; }
    }

    [XmlRoot(ElementName = "category")]
    public class Category
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "categories")]
    public class Categories
    {
        [XmlElement(ElementName = "category")]
        public List<Category> Category { get; set; }
    }

    [XmlRoot(ElementName = "param")]
    public class Param
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "offer")]
    public class Offer
    {
        [XmlElement(ElementName = "productId")]
        public string ProductId { get; set; }
        [XmlElement(ElementName = "url")]
        public string Url { get; set; }
        [XmlElement(ElementName = "price")]
        public string Price { get; set; }
        [XmlElement(ElementName = "currencyId")]
        public string CurrencyId { get; set; }
        [XmlElement(ElementName = "categoryId")]
        public string CategoryId { get; set; }
        [XmlElement(ElementName = "picture")]
        public string Picture { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "vendor")]
        public string Vendor { get; set; }
        [XmlElement(ElementName = "brand_id")]
        public string Brand_id { get; set; }
        [XmlElement(ElementName = "vendorCode")]
        public string VendorCode { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "cpa")]
        public string Cpa { get; set; }
        [XmlElement(ElementName = "param")]
        public List<Param> Param { get; set; }
        [XmlElement(ElementName = "model")]
        public string Model { get; set; }
        [XmlElement(ElementName = "sales_notes")]
        public string Sales_notes { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "available")]
        public string Available { get; set; }
    }

    [XmlRoot(ElementName = "offers")]
    public class Offers
    {
        [XmlElement(ElementName = "offer")]
        public List<Offer> Offer { get; set; }
    }

    [XmlRoot(ElementName = "shop")]
    public class Shop
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "company")]
        public string Company { get; set; }
        [XmlElement(ElementName = "url")]
        public string Url { get; set; }
        [XmlElement(ElementName = "platform")]
        public string Platform { get; set; }
        [XmlElement(ElementName = "version")]
        public string Version { get; set; }
        [XmlElement(ElementName = "email")]
        public string Email { get; set; }
        [XmlElement(ElementName = "currencies")]
        public Currencies Currencies { get; set; }
        [XmlElement(ElementName = "categories")]
        public Categories Categories { get; set; }
        [XmlElement(ElementName = "offers")]
        public Offers Offers { get; set; }
    }

    [XmlRoot(ElementName = "yml_catalog")]
    public class Yml_catalog
    {
        [XmlElement(ElementName = "script")]
        public Script Script { get; set; }
        [XmlElement(ElementName = "shop")]
        public Shop Shop { get; set; }
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }
    }
}