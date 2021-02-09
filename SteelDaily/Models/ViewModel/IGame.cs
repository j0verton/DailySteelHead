using System.Collections.Generic;

namespace SteelDaily.Models.ViewModel
{
    public interface IGame
    {
        List<bool> Outcomes { get; }
        Result Result { get; set; }
    }
}