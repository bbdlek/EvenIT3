//
//  NHNCloudUnityError.h
//  NHNCloudUnityCore
//
//  Created by JooHyun Lee on 2018. 8. 13..
//  Copyright © 2018년 NHNEnt. All rights reserved.
//

#import <Foundation/Foundation.h>

static NSString *const NHNCloudUnityErrorDomain = @"com.nhncloud.unity.core";

typedef NS_ENUM(NSInteger, NHNCloudUnityErrorCode) {
    NHNCloudUnityErrorParameterInvalid = 10000,    // 요청 파라미터 오류
    NHNCloudUnityErrorCallbackInvalid = 10007,     // 콜백 오류
    NHNCloudUnityErrorActionNotFound = 60000,      // URI 에 해당하는 Action 을 찾지 못함
    NHNCloudUnityErrorUnknown = 99999,             // 알수 없는 오류
};
