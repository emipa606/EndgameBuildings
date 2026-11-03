# GitHub Copilot Instructions for Endgame Buildings (Continued)

## Mod Overview and Purpose

**Mod Name:** Endgame Buildings (Continued)  
**Mod Description:** Update of the Squirting Elephants mod, adding more endgame buildings and integrating new features into the RimWorld game.  
**Author:** Squirting Elephant  
**Package ID:** Mlie.EndgameBuildings

The Endgame Buildings mod enhances the late-game experience in RimWorld by introducing advanced and specialized structures that help your colonists improve their skills, manage resources efficiently, and provide advanced research opportunities.

## Key Features and Systems

### New Buildings
- **Hi-Tech Kitchen:** Capable of creating Lavish Meals from basic ingredients, lunchboxes, and improving hay.
- **Study Desks:** Safe environment for colonists to learn and improve their skills.
- **Tool Cabinet:** Increases workspeed by 12% and stacks up to two times with regular tool cabinets.
- **Advanced Vitals Monitor:** Provides detailed health monitoring.
- **Ground-Penetrating Scanner (Smaller):** An improved version of the scanner.
- **Fusion Reactor:** Generates 25,000 power, a significant upgrade over Ship Reactors.
- **Armored Shelves:** Protects storage areas from damage.
- **Commode:** Improved dresser.
- **Hi-Tech Firefoam Popper:** A large and customizable explosion radius for fire suppression.

### New Items
- **Improved Hay:** Created by the Hi-Tech Kitchen.
- **Lunchbox Meal (Lavish):** A meal for traveling.
- **Lunchbox Casing:** Required for creating the Lunchbox Meal, created at the smithy.

### Integration and Compatibility
- **XML:** The mod uses XML for defining new buildings, items, and recipes. There is minimal C# code used, mainly for mod settings.
- **No Dependencies:** The mod does not depend on Harmony or HugsLib.
- **XPath Operations:** The mod includes some XPath operations for compatibility and flexibility.
- **Performance:** The mod has a similar performance impact to other comparable buildings.
- **Compatibility:** The mod is compatible with other mods like Vegetable Garden and Misc Robots++.

## Coding Patterns and Conventions

### XML Integration
- **Structure:** XML files are organized into different categories such as `DamageDefs`, `RecipeDefs`, `ThingDefs_Buildings`, and `ThingDefs_Items`.
- **Naming Conventions:** Defs are named with a prefix `EB_` to distinguish them from vanilla or other mod defs.
- **Def Types:** Common def types include `DamageDef`, `RecipeDef`, `ThingDef`, and `minifiedDef`.

### Harmony Patching
- **Usage:** While the mod does not require Harmony, it is available for any future enhancements or compatibility patches.
- **Pattern:** Harmony patches can be used to modify vanilla behavior without overwriting existing code.

### Suggestions for Copilot
- **XML Templates:** Generate XML templates for new buildings, items, and recipes following the existing naming conventions.
- **XPath Examples:** Provide examples of XPath operations used in the mod for modifying existing defs.
- **Mod Settings:** Suggest improvements for the mod settings window, such as adding new categories or improving usability.
- **Harmony Patch Examples:** Generate examples of Harmony patches for modifying vanilla behavior, focusing on performance and compatibility.

## Example XML Template

xml
<?xml version="1.0" encoding="utf-8"?>
<Defs>
    <ThingDef ParentName="BaseBuilding" Name="EB_Building_NewStructure">
        <label>New Structure</label>
        <description>A new structure for endgame content.</description>
        <costList>
            <Steel>10</Steel>
            <Silicon>5</Silicon>
        </costList>
        <building>
            <power>
                <consumption>0.5</consumption>
                <basePowerConsumption>0.5</basePowerConsumption>
            </power>
        </building>
    </ThingDef>
</Defs>


## Example XPath Operation

csharp
using RimWorld;
using Verse;
using System.Xml.Linq;

public class ExampleXPath
{
    public void ModifyDefs()
    {
        var xmlDoc = GenDefDatabase.DefToXml(DefDatabase<ThingDef>.GetNamed("Building_StoneWall"));
        var wallDef = xmlDoc.Root.Element("ThingDef");
        var buildingElement = wallDef.Element("building");
        if (buildingElement != null)
        {
            var newElement = new XElement("newElement", "newValue");
            buildingElement.Add(newElement);
        }
        GenDefDatabase.SaveDefToXml(DefDatabase<ThingDef>.GetNamed("Building_StoneWall"), xmlDoc);
    }
}


## Conclusion

The Endgame Buildings mod enriches the late-game experience in RimWorld by introducing advanced buildings and items. By following the established coding patterns and conventions, developers can contribute to or extend the mod's functionality. GitHub Copilot can assist in generating XML templates, XPath examples, and Harmony patch examples to help streamline the development process.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

