public class PlaneItem : ItemBase
{
    public static float FlightSpeed { get; } = 4;

    public static float FadeTime { get; } = 1f;

    public override string GetDescription()
    {
        return "Voici le redoutable Crayonojet 3000, le fleuron de l'aviation enfantine ! Avec un crayon comme fuselage," +
            " une r�gle ultra-a�rodynamique pour les ailes et du scotch indestructible pour tout maintenir, cet avion est pr�t � conqu�rir les cieux�" +
            " ou au moins � traverser la chambre. Attention, turbulences garanties si le vent du ventilateur se l�ve !";
    }
}
    