using System.ComponentModel.DataAnnotations;

namespace StatTrack.Models
{
    public class PlayerModel
    {
        public int Id { get; set; }

        [Display(Name = "Spillernavn")]
        [Required(ErrorMessage = "Der skal indtastes et navn på spilleren")]
        public string PlayerName { get; set; }

        [Display(Name = "Spillerposition")]
        [Required(ErrorMessage = "Der skal vælges en position på spilleren")]
        public string PlayerPosition { get; set; }

        [Display(Name = "Årgang")]
        [Required(ErrorMessage = "Fødselsår skal vælges")]
        [Range(1900, 2100, ErrorMessage = "Vælg venligst et valid årstal")]
        public int YOB { get; set; }
    }
}