//
//  NHNCloudUnityAsyncAction.h
//  NHNCloudUnityCore
//
//  Created by JooHyun Lee on 2018. 3. 12..
//  Copyright © 2018년 NHNEnt. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "NHNCloudUnityAction.h"

@interface NHNCloudUnityAsyncAction : NHNCloudUnityAction

- (void)action:(NHNCloudUnityMessage *)message completionHandler:(void (^)(NHNCloudNativeMessage *nativeMessage))completionHandler;

@end
