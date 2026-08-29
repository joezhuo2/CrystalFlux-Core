# CrystalFlux Core

Core gameplay contracts shared across CrystalFlux systems. This package defines
the shared interfaces and data types that other CrystalFlux packages implement
and consume — it contains no scene assets, prefabs, or concrete gameplay
behaviours, only the shapes systems agree on.

Kept in sync with the in-game copies of these contracts in
[joezhuo2/Anamnesis](https://github.com/joezhuo2/Anamnesis).

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
    CrystalFlux.Core.asmdef            # CrystalFlux.Core namespace
    DamageInstance.cs
    DamagePacket.cs
    ICurrencyHolder.cs
    IOnHitEffect.cs
    IStatProvider.cs
    IUnlockEffect.cs
    IUnlockRequirement.cs
    ResourceType.cs
    StatBuff.cs
    StatType.cs
    TypeSelectorAttribute.cs
    EntitySystem/
        CrystalFlux.EntitySystem.asmdef    # CrystalFlux.EntitySystem namespace, references Core
        IDamageable.cs
        IKnockbackable.cs
        IResourcePool.cs
        ITeamMember.cs
    ProjectileSystem/
        CrystalFlux.ProjectileSystem.asmdef  # CrystalFlux.ProjectileSystem namespace
        IOrbitRegistrar.cs                   # defines IOrbitRegister
        ISummonTrigger.cs
    SkillTree/
        CrystalFlux.SkillTree.asmdef       # CrystalFlux.SkillTree namespace
        ISkillPointHolder.cs
    StatusEffectSystem/
        CrystalFlux.StatusEffectSystem.asmdef  # CrystalFlux.StatusEffectSystem namespace
        IStatusEffectReceiver.cs
    UISystem/
        CrystalFlux.UISystem.asmdef        # CrystalFlux.UISystem namespace
        IAnnouncer.cs
        ITooltipDisplay.cs
```

## Assemblies

| Assembly | Namespace | Depends on |
|---|---|---|
| `CrystalFlux.Core` | `CrystalFlux.Core` | — |
| `CrystalFlux.EntitySystem` | `CrystalFlux.EntitySystem` | `CrystalFlux.Core` |
| `CrystalFlux.ProjectileSystem` | `CrystalFlux.ProjectileSystem` | — |
| `CrystalFlux.SkillTree` | `CrystalFlux.SkillTree` | — |
| `CrystalFlux.StatusEffectSystem` | `CrystalFlux.StatusEffectSystem` | — |
| `CrystalFlux.UISystem` | `CrystalFlux.UISystem` | — |

## Contents

**`CrystalFlux.Core`**
- `DamageInstance` / `DamagePacket` — a single damage event and a batched set of
  events dealt together (crits, damage type, indicator color, source).
- `ICurrencyHolder` — spend/add/query an integer currency balance.
- `IOnHitEffect` — a projectile-hit effect hook.
- `IStatProvider` — read a stat value and apply/remove stat buffs.
- `IUnlockEffect` / `IUnlockRequirement` — apply/remove an unlock's effect, and
  gate an unlock behind a requirement.
- `StatType` — the full stat enum (offense, defense, resources, movement, and
  entity-state stats).
- `StatBuff` — a `(StatType, value)` pair with display-name formatting and
  removal helper.
- `ResourceType` — `Stamina`, `Mana`.
- `TypeSelectorAttribute` — property attribute for type-picker inspector drawers.

**`CrystalFlux.EntitySystem`**
- `IDamageable` — receive a `DamagePacket`, trigger i-frames, report alive
  state, and fire an `OnDeath` event.
- `IKnockbackable` — apply a directional knockback.
- `IResourcePool` — spend/gain a typed resource (stamina, mana).
- `ITeamMember` — team/faction identity for friend-or-foe checks.

**`CrystalFlux.ProjectileSystem`**
- `IOrbitRegister` (in `IOrbitRegistrar.cs`) — register/unregister orbiting
  projectiles and report the current count.
- `ISummonTrigger` — attempt to summon at a position.

**`CrystalFlux.SkillTree`**
- `ISkillPointHolder` — hold, add, and spend skill points.

**`CrystalFlux.StatusEffectSystem`**
- `IStatusEffectReceiver` — apply/clear/query/remove status effects by type.

**`CrystalFlux.UISystem`**
- `IAnnouncer` — show/hide timed title and subtitle banners.
- `ITooltipDisplay` — show/hide a positioned tooltip.

## Known gaps

Two interfaces are ported with the same signatures as the game project, but
reference concrete types that live in the game rather than in this package:

- `CrystalFlux.ProjectileSystem.IOrbitRegister` references `Projectile`
  (a `MonoBehaviour`).
- `CrystalFlux.StatusEffectSystem.IStatusEffectReceiver` references
  `StatusEffect` (an abstract `ScriptableObject`).

A consuming project must supply both types for those two files to compile;
they are intentionally not duplicated here since they carry game-specific
implementation, not a shared contract.

## Requirements

Unity 2022.3 or later.
