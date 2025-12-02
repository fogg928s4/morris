using System;

public class Planet : Body {

    // Constructors
    public Planet() {
        this.name = "Earth";
        this.baseMass = 5.97;
        this.trueMass = baseMass * Math.Pow(10, 24);
    }
    public Planet(string name, double baseMass) {
        this.name = name;
        this.baseMass = baseMass;
        this.trueMass = this.baseMass * Math.Pow(10, 24);
    }
    public Planet(string name) {
        this.name = name;
        this.baseMass = 5.97;
        this.trueMass = baseMass * Math.Pow(10, 24);
    }

    // Properties
    public Name {
        get { return name; }
set { name = value; }
    }
    public Mass {
    get { return baseMass; }
    set {
        baseMass = value;
        trueMass = baseMass * Math.Pow(10, 24);
    }
}
}