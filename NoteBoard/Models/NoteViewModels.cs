using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NoteBoard.Models
{
    public class PrivateNoteViewModel
    {
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Field must have between 2 and 50 characters")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Field must have between 2 and 50 characters")]
        [Display(Name = "Text Content")]
        public string TextContent { get; set; }


    }
}