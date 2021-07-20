using System.ComponentModel.DataAnnotations;

namespace product.Models
{

  public class Product
  {
    public int Id { get; set; }
    [Required]
    [MaxLength(20)]
    public string Title { get; set; }
    public string Body { get; set; }
    public string imgUrl { get; set; }

  }


}
