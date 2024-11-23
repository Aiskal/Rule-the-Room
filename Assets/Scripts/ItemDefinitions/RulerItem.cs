public class RulerItem : ItemBase
{
    public static float BaseRotation { get; } = 30;

    public static float SpawnRotation { get => BaseRotation; }

    public static float TimeAlive { get; } = 6f;

    public static string GetDescription()
    {
        return "Cette r�gle en plastique transparent, avec des chiffres l�g�rement effac�s, est un guide pr�cieux pour maintenir les choses droites et align�es." +
            " Dans l�esprit de l�enfant, elle devient une passerelle entre l�ordre et le chaos, un outil pour construire quelque chose de solide malgr� l�incertitude." +
            " Peut-�tre, avec un peu de magie, elle pourrait servir � b�tir un chemin pour le retour de son h�ros";
    }
}
    
