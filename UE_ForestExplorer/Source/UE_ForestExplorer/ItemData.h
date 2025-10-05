// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Engine/DataAsset.h"
#include "ItemData.generated.h"

/**
 * 
 */
UCLASS()
class UE_FORESTEXPLORER_API UItemData : public UDataAsset
{
	GENERATED_BODY()

	UPROPERTY(EditDefaultsOnly)
	int32 ItemID;

	UPROPERTY(EditDefaultsOnly)
	FString ItemName;

	UPROPERTY(EditDefaultsOnly)
	UStaticMesh* ItemStaticMesh;
	
	UPROPERTY(EditDefaultsOnly)
	UTexture2D* ItemIcon;
};
