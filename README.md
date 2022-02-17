# StulProgramy
Programy pro stůl na LEGO projekty
## Programy
- Náhodné pixely

## Přidávání programů
Každý program musí obsahovat minimálně 3 soubory:
- Třídu, která implementuje rozhraní [```IProgram```](StulProgramy/IProgram.cs)
- ```UserConrol```, který bude zobrazen uživateli a umožnujě program nastavovat
- Obrázek, který bude zobrazen v seznamu programů

Příklad pro třídu implementující [```IProgram```](StulProgramy/IProgram.cs):
```csharp
public class NahodnePixely : IProgram
{
    public UserControl Zobrazeni { get; set; }
    public Stul Stul { get; set; }
    
    public event EventHandler? PriUkonceniProgramu;

    public NahodnePixely(Stul s)
    {
        Stul = s;
        Zobrazeni = new NahodnePixelyZobrazeni();
    }
    

    public void Ukoncit()
    {
        PriUkonceniProgramu?.Invoke(this, EventArgs.Empty);
    }
}
```
Poté musí být program přidán do seznamu programů v [```MainWindow.xaml.cs```](StulProgramy/MainWindow.xaml.cs) v metodě ```NaplnitProgramy```
Do metody přidejte následující kód:
```csharp
pd = new();
pd.Nazev = "Náhodné pixely";
pd.Obrazek = "NahodnePixelyIkona.png";
pd.Popis = "Program vygeneruje náhodné pixely, které musí být nalezeny a označeny magnetem";
pd.Vytvorit = (s) => new NahodnePixely(s);
programy.Add(pd);
```
