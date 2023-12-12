using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        //CategoryId foreign key
        [Range(1,int.MaxValue,ErrorMessage = "Please select a category. ")]
        public int CategoryId { get; set; }

        //navigational property that points to the categoryID primary key make it nullable since it is
        //not bound in controller POST method
        public Category? Category { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than 0.")]
        public int Amount { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public string? Note { get; set; }

        //Default to todays date
        /*[DisplayFormat(DataFormatString = "{0:MMM-dd-yy}", ApplyFormatInEditMode = true)]*/
        public DateTime Date { get; set; } = DateTime.Now;
    /*    public string FormattedDate => Date.ToString("MMM-dd-yy");*/

        [NotMapped] 
        public string? CategoryTitleWithIcon 
        {
            get
            {
                return Category==null ? "": Category.Icon + " " + Category.Title;
            }
                
        }

        [NotMapped]
        //If the type is an expense or null make it negative else its an income
        public string? FormattedAmount
        {
            get
            {
                return ((Category == null || Category.Type == "Expense") ? "- " : "+ ") + Amount.ToString("C0");
            }
        }
    }
}
