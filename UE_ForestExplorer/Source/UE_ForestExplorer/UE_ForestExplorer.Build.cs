// Copyright Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;

public class UE_ForestExplorer : ModuleRules
{
	public UE_ForestExplorer(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

		PublicDependencyModuleNames.AddRange(new string[] {
			"Core",
			"CoreUObject",
			"Engine",
			"InputCore",
			"EnhancedInput",
			"AIModule",
			"NavigationSystem",
			"StateTreeModule",
			"GameplayStateTreeModule",
			"Niagara",
			"UMG",
			"Slate"
		});

		PrivateDependencyModuleNames.AddRange(new string[] { });

		PublicIncludePaths.AddRange(new string[] {
			"UE_ForestExplorer",
			"UE_ForestExplorer/Variant_Strategy",
			"UE_ForestExplorer/Variant_Strategy/UI",
			"UE_ForestExplorer/Variant_TwinStick",
			"UE_ForestExplorer/Variant_TwinStick/AI",
			"UE_ForestExplorer/Variant_TwinStick/Gameplay",
			"UE_ForestExplorer/Variant_TwinStick/UI"
		});

		// Uncomment if you are using Slate UI
		// PrivateDependencyModuleNames.AddRange(new string[] { "Slate", "SlateCore" });

		// Uncomment if you are using online features
		// PrivateDependencyModuleNames.Add("OnlineSubsystem");

		// To include OnlineSubsystemSteam, add it to the plugins section in your uproject file with the Enabled attribute set to true
	}
}
