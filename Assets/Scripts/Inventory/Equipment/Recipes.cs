using System;
using System.Collections.Generic;
using System.Linq;

public class Recipe
{
    public List<ItemIdentifier> items;
    public ItemIdentifier givenItem;

    public Recipe(List<ItemIdentifier> items, ItemIdentifier givenItem)
    {
        this.items = items;
        this.givenItem = givenItem;
    }
}

public static class Reciepes
{
    public static List<Recipe> reciepesList = new()
    {
        new Recipe( new List<ItemIdentifier>() { ItemIdentifier.Pencil }, ItemIdentifier.Pencil ),
        new Recipe( new List<ItemIdentifier>() { ItemIdentifier.Eraser }, ItemIdentifier.Eraser ),
        new Recipe( new List<ItemIdentifier>() { ItemIdentifier.Ruler }, ItemIdentifier.Ruler ),
        new Recipe( new List<ItemIdentifier>() { ItemIdentifier.Skotch }, ItemIdentifier.Skotch ),
        new Recipe( new List<ItemIdentifier>() { ItemIdentifier.Pencil, ItemIdentifier.Ruler, ItemIdentifier.Skotch }, ItemIdentifier.Plane ),
        new Recipe( new List<ItemIdentifier>() { ItemIdentifier.Pencil, ItemIdentifier.Eraser}, ItemIdentifier.Hammer ),
        new Recipe( new List<ItemIdentifier>() { ItemIdentifier.Eraser, ItemIdentifier.Ruler }, ItemIdentifier.Catapults )
    };

    public static ItemIdentifier TryRecipe(List<ItemIdentifier> combinaison)
    {
        Recipe recipe = reciepesList.FirstOrDefault(r => AreListsEqual(r.items, combinaison));
        if(recipe == null)
        {
            return ItemIdentifier.None;
        }
        else
        {
            return recipe.givenItem;
        }
    }
 
    public static bool AreListsEqual<T>(IEnumerable<T> list1, IEnumerable<T> list2) where T : Enum
    {
        if (list1 == null || list2 == null)
            return list1 == list2;

        var set1 = new HashSet<T>(list1);
        var set2 = new HashSet<T>(list2);

        return set1.SetEquals(set2);
    }

}


    //private static List<Type> _itemTypes; 

    //public static IReadOnlyList<Type> ItemTypes
    //{
    //    get
    //    {
    //        if (_itemTypes == null)
    //        {
    //            _itemTypes = Assembly.GetExecutingAssembly()
    //                .GetTypes()
    //                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(ItemBase)))
    //                .ToList();
    //        }
    //        return _itemTypes;
    //    }
    //}

    //public static T CreateItem<T>() where T : ItemBase
    //{
    //    return Activator.CreateInstance<T>();
    //}

    //public static ItemBase CreateItem(Type itemType)
    //{
    //    if (!itemType.IsSubclassOf(typeof(ItemBase)))
    //        throw new ArgumentException($"Le type {itemType.Name} n'hérite pas de ItemBase");

    //    return (ItemBase)Activator.CreateInstance(itemType);
    //}



