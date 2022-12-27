//
//  NHNCloudUnityLogger+SDK.h
//  NHNCloudUnityLogger
//
//  Created by JooHyun Lee on 2018. 2. 27..
//  Copyright © 2018년 NHNEnt. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <NHNCloudUnityCore/NHNCloudUnityCore.h>
#import <NHNCloudLogger/NHNCloudLogger.h>

@interface NHNCloudUnityLogger : NSObject <NHNCloudUnityModule>

+ (NSString *)version;

@end
