//
//  NHNCloudUnityUtil.h
//  NHNCloudUnityCore
//
//  Created by JooHyun Lee on 2018. 2. 28..
//  Copyright © 2018년 NHNEnt. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <NHNCloudCore/NHNCloudCore.h>

@interface NHNCloudUnityUtil : NSObject

+ (BOOL)respondsToClassName:(NSString *)className;
+ (BOOL)respondsToSelector:(SEL)selector forClass:(Class)class;
+ (BOOL)performSelector:(SEL)selector forClass:(Class)class withObject:(id)object;

+ (char *)cStringCopy:(const char *)string;
+ (const char *)cStringWithString:(NSString *)string;
+ (NSString *)stringWithCString:(const char *)cString;

+ (const char *)cStringWithJSONObject:(id)object;
+ (NSString *)stringWithJSONObject:(id)object;
+ (id)objectWithJSONString:(NSString *)string;

+ (NSString *)matchStringInURI:(NSString *)uri withPattern:(NSString *)pattern;

+ (NHNCloudServiceZone)serviceZoneWithString:(NSString *)string;

@end
