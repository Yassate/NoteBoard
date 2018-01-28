using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace NoteBoard.Models
{
    public enum BoardType { Public, Private, Shared}

    public class Board
    {
        [Key]
        public int MainBoardId { get; set; }
        public BoardType BoardType { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public ICollection<ApplicationUser> ApprovedUsers { get; set; }
        public ICollection<SingleNote> SingleNotes { get; set; }

    }

    public class SingleNote
    {
        [Key]
        public int SingleNoteId { get; set; }

        public string TextContent { get; set; }

        public int BoardId { get; set; }
        [ForeignKey("BoardId")]
        public virtual Board Board { get; set; }
        
    }
}