# Changelog

All notable changes to this package are documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

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
