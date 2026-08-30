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

Everything lives in the `CrystalFlux.Core` namespace and compiles as a single
assembly. Subfolders are organizational only — none of them carry their own
`.asmdef`.

```
Runtime/
    CrystalFlux.Core.asmdef        # the only assembly in this package
    DamageInstance.cs
    DamagePacket.cs
    DamageRoll.cs
    ICurrencyHolder.cs
    IOnHitEffect.cs
    InputState.cs
    IStatProvider.cs
    IUnlockEffect.cs
    IUnlockRequirement.cs
    ResourceType.cs
    StatBuff.cs
    StatType.cs
    TypeSelectorAttribute.cs
    EntitySystem/
        IDamageable.cs
        IKnockbackable.cs
        IResourcePool.cs
        ITeamMember.cs
        IUpgradeHolder.cs
        SummonCondition.cs
        UpgradeAsset.cs
    ProjectileSystem/
        AttackAsset.cs             # also defines AttackType
        IAttackHandler.cs
        ISummonTrigger.cs
    SkillTree/
        ISkillPointHolder.cs
    StatusEffectSystem/
        EffectAsset.cs
        IStatusEffectReceiver.cs
    UISystem/
        IAnnouncer.cs
        ITooltipDisplay.cs
```

## Assembly

| Assembly | Namespace | Depends on |
|---|---|---|
| `CrystalFlux.Core` | `CrystalFlux.Core` | — |

## Contents

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
- `DamageRoll` — crit rolling and `DamagePacket` construction from a source's
  `IStatProvider`.
- `InputState` — shared pointer position.
- `AttackAsset` / `AttackType` / `IAttackHandler` — the abstract attack
  ScriptableObject, its category enum, and the holder contract.
- `EffectAsset` / `IStatusEffectReceiver` — the abstract effect ScriptableObject
  and the contract for applying, querying, and removing effects on a target.
- `UpgradeAsset` / `IUpgradeHolder` — the abstract upgrade ScriptableObject and
  the holder contract.
- `SummonCondition` — when a summon triggers.
- `ResourceType` — `Stamina`, `Mana`.
- `TypeSelectorAttribute` — property attribute for type-picker inspector drawers.
- `IDamageable` — receive a `DamagePacket`, trigger i-frames, report alive
  state, and fire an `OnDeath` event.
- `IKnockbackable` — apply a directional knockback.
- `IResourcePool` — spend/gain a typed resource (stamina, mana).
- `ITeamMember` — team/faction identity for friend-or-foe checks.
- `IOrbitRegister` (in `IOrbitRegistrar.cs`) — register/unregister orbiting
  projectiles and report the current count.
- `ISummonTrigger` — attempt to summon at a position.
- `ISkillPointHolder` — hold, add, and spend skill points.
- `IStatusEffectReceiver` — apply/clear/query/remove status effects by type.
- `IAnnouncer` — set, show for a duration, and hide title and subtitle
  banners.
- `ITooltipDisplay` — show/hide a positioned tooltip.

## Known gaps

Two interfaces are ported with the same signatures as the game project, but
reference concrete types that live in the game rather than in this package:

- `IOrbitRegister` references `Projectile` (a `MonoBehaviour`).
- `IStatusEffectReceiver` references `StatusEffect` (an abstract
  `ScriptableObject`).

A consuming project must supply both types for those two files to compile;
they are intentionally not duplicated here since they carry game-specific
implementation, not a shared contract.

## Requirements

Unity 2022.3 or later.
