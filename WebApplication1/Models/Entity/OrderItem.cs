using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.Entity
{
	[Table("OrderItems")]
	public class OrderItem : BaseEntity<int>
	{
		public int ProductId { get; set; }

		[ForeignKey("ProductId")]
		public Product Product { get; set; }

		public int Quantity { get; set; }

		public double Price { get; set; }

	}
}
