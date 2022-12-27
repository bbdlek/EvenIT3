//
//  NHNCloudUnityAction.h
//  NHNCloudUnityCore
//
//  Created by JooHyun Lee on 2018. 3. 12..
//  Copyright © 2018년 NHNEnt. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <NHNCloudCommon/NHNCloudCommon.h>
#import "NHNCloudNativeMessage.h"

@interface NHNCloudUnityAction : NSObject

@property (nonatomic, readonly, copy) NSString *uri;

- (instancetype)initWithURI:(NSString *)uri;

@end
