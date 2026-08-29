# Changelog

All notable changes to this package are documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

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
