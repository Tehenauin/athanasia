using UnityEngine.UI;

public class CharacterCardDrawer{

    [SerializeField] private TextMeshProUGUI CharacterNameText;
    [SerializeField] private Image CharacterPortrait;
    [SerializeField] private TextMeshProUGUI BountyText;
    
    


}

public class Character{
  public string Form;
  public string[] Genes;
  public string Class;
  public string[] Abilities;
}

public class ComponentLibrary{
  public T GetCharacterComponent<T> where T is CharacterComponent(string componentName){
      
  }
}
