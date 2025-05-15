namespace Board_Game_Ledger.DTOs.BoardGame
{
    public class BoardGameDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int MinPlayerCount { get; set; }
        public int MaxPlayerCount { get; set; }
    }
}
