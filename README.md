# CrystalFlux Core

Core gameplay contracts shared across CrystalFlux systems. This package defines
the shared interfaces and data types that other CrystalFlux packages implement
and consume — it contains no scene assets, prefabs, or concrete gameplay
behaviours, only the shapes systems agree on.

## Installation

Add via the Unity Package Manager using a Git URL:

```
https://github.com/joezhuo2/CrystalFlux-Core.git
```

Or add directly to `Packages/manifest.json`:

```json
"com.crystalflux.core": "https://github.com/joezhuo2/CrystalFlux-Core.git"
```

## Structure

```
Runtime/
    CrystalFlux.Core.asmdef       # CrystalFlux.Core namespace
    DamageInstance.cs
    DamagePacket.cs
    ICurrencyHolder.cs
    IStatProvider.cs
    ITeamMember.cs
    IUnlockEffect.cs
    IUnlockRequirement.cs
    TypeSelectorAttribute.cs
    UISystem/
        CrystalFlux.UISystem.asmdef   # CrystalFlux.UISystem namespace, references Core
        IAnnouncer.cs
        ITooltipDisplay.cs
```

## Assemblies

| Assembly | Namespace | Depends on |
|---|---|---|
| `CrystalFlux.Core` | `CrystalFlux.Core` | — |
| `CrystalFlux.UISystem` | `CrystalFlux.UISystem` | `CrystalFlux.Core` |

## Contents

**`CrystalFlux.Core`**
- `DamageInstance` / `DamagePacket` — a single damage event and a batched set of
  events dealt together (crits, damage type, indicator color, source).
- `ICurrencyHolder` — spend/add/query an integer currency balance.
- `IStatProvider` — read a stat value and apply/remove stat buffs.
- `ITeamMember` — team/faction identity for friend-or-foe checks.
- `IUnlockEffect` / `IUnlockRequirement` — apply/remove an unlock's effect, and
  gate an unlock behind a requirement.
- `TypeSelectorAttribute` — property attribute for type-picker inspector drawers.

**`CrystalFlux.UISystem`**
- `IAnnouncer` — show/hide timed title and subtitle banners.
- `ITooltipDisplay` — show/hide a positioned tooltip.

## Known gaps

`IStatProvider` references `StatType` and `StatBuff`, which are not yet defined
in this package. A stats package providing those types must be present for
`CrystalFlux.Core` to compile.

## Requirements

Unity 2022.3 or later.
