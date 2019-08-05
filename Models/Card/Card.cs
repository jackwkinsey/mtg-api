using System.Collections.Generic;

namespace mtg_api.Models
{
  public class Card
  {
    public string Name { get; set; }
    public string Rarity { get; set; }
    public int CollectionNumber { get; set; }
    public string SetName { get; set; }
    public string SetCode { get; set; }
    public string CastingCost { get; set; }
    public string Text { get; set; }
    public string FlavorText { get; set; }
    public string Type { get; set; }
    public string SubType { get; set; }
    public int Power { get; set; }
    public int Toughness { get; set; }
    public string Artist { get; set; }
    public string ImageUrl { get; set; }
    public bool Foil { get; set; }
  }
}
