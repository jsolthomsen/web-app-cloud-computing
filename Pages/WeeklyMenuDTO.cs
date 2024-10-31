using System;


namespace WeeklyMenu
{
    public record WeeklyMenuDTO
    {
        public string? UgeDag { get; set; }
        public string? VarmRet { get; set; }
        public string? KoldRet { get; set; }
    }
}