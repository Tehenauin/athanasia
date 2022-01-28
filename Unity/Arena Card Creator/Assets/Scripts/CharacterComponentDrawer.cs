using System;
using UnityEngine.Events;
using UnityEngine.UIElements;

public abstract class CharacterComponentDrawer {

    public CharacterComponent Component{ get; protected set; }
    public abstract Type ComponentType { get;}
    public VisualElement VisualElement;
    protected Label name;
    protected Label bounty;
    public static UnityEvent<CharacterComponent> ComponentSelect = new UnityEvent<CharacterComponent>();
    protected void Initialize() {
        VisualElement.RegisterCallback<MouseDownEvent>( evt => ComponentSelect.Invoke(Component));
    }
    public abstract void Update(CharacterComponent component);

}

public class FormDrawer : CharacterComponentDrawer {
    public Form Form => Component as Form;
    public override Type ComponentType => typeof(Form);

    private Label stats;

    public FormDrawer(VisualTreeAsset template, Form form) {
        VisualElement = template.Instantiate();
        name = VisualElement.Q<Label>("Name");
        bounty = VisualElement.Q<Label>("Bounty");
        stats = VisualElement.Q<Label>("Stats");
        Update(form);
        Initialize();
    }

    public override void Update(CharacterComponent component) {
        Component = component;
        name.text = Form.Name;
        bounty.text = Form.Bounty.ToString();
        stats.text = Form.BaseStats.ToString();
    }
}
public class GeneDrawer : CharacterComponentDrawer {
    public Gene Gene => Component as Gene;
    public override Type ComponentType => typeof(Gene);

    public GeneDrawer(VisualTreeAsset template, Gene gene) {
        VisualElement = template.Instantiate();
        name = VisualElement.Q<Label>("Name");
        Update(gene);
        Initialize();
    }

    public override void Update(CharacterComponent component) {
        Component = component;
        name.text = Gene.Name;
    }
}
public class CClassDrawer : CharacterComponentDrawer {
    public CClass CClass => Component as CClass;
    public override Type ComponentType => typeof(CClass);
    public CClassDrawer(VisualTreeAsset template, CClass cClass) {
        VisualElement = template.Instantiate();
        name = VisualElement.Q<Label>("Name");
        Update(cClass);
        Initialize();
    }

    public override void Update(CharacterComponent component) {
        Component = component;
        name.text = CClass.Name;
    }
}

public class AbilityDrawer : CharacterComponentDrawer {
    public Ability Ability => Component as Ability;
    public override Type ComponentType => typeof(Ability);
    public AbilityDrawer(VisualTreeAsset template, Ability ability) {
        VisualElement = template.Instantiate();
        name = VisualElement.Q<Label>("Name");
        Update(ability);
        Initialize();
    }

    public override void Update(CharacterComponent component) {
        Component = component;
        name.text = Ability.Name;
    }
}