//
//  NHNCloudUnity.h
//  NHNCloudUnity
//
//  Created by JooHyun Lee on 2018. 2. 28..
//  Copyright © 2018년 NHNEnt. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "NHNCloudUnityAction.h"
#import "NHNCloudUnityMessage.h"
#import "NHNCloudNativeMessage.h"

@protocol NHNCloudUnityModule

+ (void)registerActions;

@end

@interface NHNCloudUnity : NSObject

+ (void)registerAction:(NHNCloudUnityAction *)action;

+ (char *)didReceiveUnityMessage:(NHNCloudUnityMessage *)unityMessage;

+ (void)sendNativeMessageToUnity:(NHNCloudNativeMessage *)nativeMessage;

+ (NSString *)version;

@end
