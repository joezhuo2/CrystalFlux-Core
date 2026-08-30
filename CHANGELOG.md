# Changelog

All notable changes to this package are documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [0.7.0] - 2026-08-30

### Added
- **Breaking:** `IAnnouncer` gains `SetTitle(string)` and `SetSubtitle(string)`
  for showing a title or subtitle that stays on screen until it is changed or
  disabled, complementing the existing timed `SetTitleForDuration` /
  `SetSubtitleForDuration` calls. Existing implementers must add both members.

## [0.6.1] - 2026-08-29

### Fixed
- Added the missing `.meta` files for `package.json`, `README.md` and
  `CHANGELOG.md`. Without them Unity logs "has no meta file, but it's in an
  immutable folder. The asset will be ignored." for each on import.

## [0.6.0] - 2026-08-29

### Added
- `AttackAsset.GetTooltipLines` and `UpgradeAsset.GetTooltipLines` — abstract
  description hooks. A UI that shows an attack or upgrade no longer needs to know
  the concrete stat schema; the system that owns the data describes it.

## [0.5.0] - 2026-08-29

### Added
- `IBossBar` — boss health bar contract (`Setup(string, IStatProvider)`), so wave
  logic can drive a boss bar without referencing the entity system.
- `EnemySpawning` — a spawn hook an entity system registers at startup, letting
  other systems spawn enemies without a compile-time dependency on the spawner.
- `PlayerEvents.OnPlayerTakeDamage` — player damage notification, relocated here
  from the entity system's own static event.

### Changed
- `IStatusEffectReceiver` gains `DisplayPrefab` and `DisplayContainer` setters, so
  a caller can configure effect-icon display without touching the concrete manager.

## [0.4.0] - 2026-08-29

### Added
- The remaining shared contracts from Anamnesis's `Assets/scripts/Core`, each of
  which is consumed by two or more systems that do not reference one another and
  therefore cannot live in any single system assembly:
  `AttackAsset` (+ `AttackType`), `IAttackHandler`, `EffectAsset`,
  `UpgradeAsset`, `IUpgradeHolder`, `SummonCondition`, `InputState`,
  and `DamageRoll`.
- `.meta` files for every asset and folder in the package, carrying the GUIDs
  from the Anamnesis originals so references survive the move.

### Fixed
- `IStatusEffectReceiver` referred to `StatusEffect`, a concrete class that
  lives downstream in Anamnesis's `CrystalFlux.StatusEffect` assembly and is not
  visible from `CrystalFlux.Core` — the package could not compile. It now uses
  `EffectAsset`, the Core-side base class it derives from.

### Removed
- `IOrbitRegistrar.cs` (`IOrbitRegister`). Its members took the concrete
  `Projectile` MonoBehaviour, also downstream of Core and likewise uncompilable
  here. It had no consumers.

## [0.3.0] - 2026-08-29

### Changed
- **Breaking:** collapsed every type back into a single `CrystalFlux.Core`
  namespace and a single `CrystalFlux.Core` assembly. The `EntitySystem`,
  `ProjectileSystem`, `SkillTree`, `StatusEffectSystem`, and `UISystem`
  namespaces and their `.asmdef` files (introduced in 0.2.0) are removed;
  `IDamageable`, `IKnockbackable`, `IResourcePool`, `ITeamMember`,
  `IOrbitRegister`, `ISummonTrigger`, `ISkillPointHolder`,
  `IStatusEffectReceiver`, `IAnnouncer`, and `ITooltipDisplay` now live in
  `CrystalFlux.Core`. Folder layout under `Runtime/` is unchanged and purely
  organizational — none of the subfolders carry their own asmdef anymore.

## [0.2.0] - 2026-08-29

Synced with the current state of the shared contracts in
[joezhuo2/Anamnesis](https://github.com/joezhuo2/Anamnesis).

### Added
- `StatType` and `ResourceType` enums, extracted from Anamnesis's stat sheet,
  resolving the `IStatProvider`/`StatBuff` compile gap from 0.1.0.
- `StatBuff` struct (stat/value pair with display-name formatting and a
  `Remove` helper).
- `IOnHitEffect` (`CrystalFlux.Core`) — projectile-hit effect hook.
- New `CrystalFlux.EntitySystem` assembly (references `CrystalFlux.Core`):
  `IDamageable`, `IKnockbackable`, `IResourcePool`.
- New `CrystalFlux.ProjectileSystem` assembly: `IOrbitRegister` (in
  `IOrbitRegistrar.cs`), `ISummonTrigger`.
- New `CrystalFlux.SkillTree` assembly: `ISkillPointHolder`.
- New `CrystalFlux.StatusEffectSystem` assembly: `IStatusEffectReceiver`.

### Changed
- **Breaking:** `ITeamMember` moved from `CrystalFlux.Core` to the new
  `CrystalFlux.EntitySystem` namespace/assembly, matching Anamnesis.
- `CrystalFlux.UISystem` no longer references `CrystalFlux.Core` — neither
  `IAnnouncer` nor `ITooltipDisplay` actually depend on it.

### Fixed
- Dropped an unused `using CrystalFlux.ProjectileSystem;` from `IOnHitEffect`
  that would otherwise force an unnecessary (and backwards) assembly
  reference from `Core` onto `ProjectileSystem`.

## [0.1.0] - 2026-08-29

### Added
- Initial package structure with `package.json` and split `Runtime` assemblies:
  `CrystalFlux.Core` and `CrystalFlux.UISystem` (referencing `Core`).
- `DamageInstance` and `DamagePacket` for representing and batching damage events.
- `ICurrencyHolder` for spendable/addable integer currency.
- `IStatProvider` for reading stats and applying stat buffs.
- `ITeamMember` for team/faction identity.
- `IUnlockEffect` and `IUnlockRequirement` for gated unlockables.
- `TypeSelectorAttribute` for inspector type-picker drawers.
- `IAnnouncer` and `ITooltipDisplay` UI-facing contracts.
