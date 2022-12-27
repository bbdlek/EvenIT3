//
//  NHNCloudUnityLoggerError.h
//  NHNCloudUnityLogger
//
//  Created by JooHyun Lee on 2018. 11. 13..
//  Copyright © 2018년 NHNEnt. All rights reserved.
//

#import <Foundation/Foundation.h>

typedef NS_ENUM(NSInteger, NHNCloudUnityLoggerErrorCode) {
    NHNCloudUnityLoggerErrorLoggerNotInitialized = 20000,  // Logger 초기화 되지 않음
    NHNCloudUnityLoggerErrorUserFieldKeyInvalid = 20002,   // 잘못된 UserKey 혹은 UserValue 입력
    NHNCloudUnityLoggerErrorCrashReportNotFound = 20003,   // PLCrashReport 링크되지 않음
};
