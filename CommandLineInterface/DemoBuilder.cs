namespace CommandLineInterface
{
    using System.Linq;
    using BoardGame;
    using BoardGame.Util;
    using TerraMystica.Util;
    using TerraMystica.Terrain;

    public class DemoBuilder
    {
        internal IBoard<TerraTile> Build()
        {
            var r = 
            " P M F L D W P S W F L W S  " +
            "  D R R P S R R D S R R D V " +
            " V R S R M R F R F R M R V  " +
            "  F L D R R W L R W R W P V " +
            " S P W L S P M D R R F S L  " +
            "  M F R R D F R R R P M P V " +
            " V R R M R W R F R D S L D  " +
            "  D L P R R R L S R M P M V " +
            " W S M L W F D W M R L F W  ";

            return new Board<TerraTile>()
            {
                Tiles = HexTileBuilder.CreateHexGrid(13, 9, r.Parse().ToArray()),
            };
        }
    }
}
