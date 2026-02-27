using System.Text.Json.Serialization;

namespace CriproBack.Models.Externos
{
    public class CriptoYaResponse
    {
        public decimal Bid { get; set; }  // Precio de venta (te pagan)
        public decimal Ask { get; set; }  // Precio de compra (pagás)
        public decimal TotalAsk { get; set; }
        public decimal TotalBid { get; set; }
        public long Timestamp { get; set; }
    }
}
