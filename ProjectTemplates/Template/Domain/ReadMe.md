# Domain
This will contain all entities, enums, exceptions, types and logic specific to the domain. The Domain has no Dependencies.

### Entities
Entitäten der Domäne. POCO's (Plain old CLR object's). **Keine** Vererbung oder Attribute

### Exceptions
###### Errors.cs
Zugriff auf Fehler mit typisierten Parametern.
FooBarException sollte eine Ableitung von DomainException sein. Jeder Fehler hat seine eigene Exception
```
  public static Exception InvalidFooBar(int foo)
    => new FooBarException("Foo: '{0}' ist keine gültige Bar", foo);
```

### Localization
* SharedResources.resx (**default**, enthält den CodeGenerator für die generierten Zugriffe)
  *  SharedResources.Designer.cs
* SharedResources.\{isocode}.resx (optional)

