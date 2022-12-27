#import <NHNCloudUnityCore/NHNCloudUnityCore.h>

NSString *stringWithCString(const char *string) {
    NSString *convertString;
    
    if (string == NULL) {
        convertString = nil;
        
    } else if (strncmp(string, "", strlen(string)) == 0) {
        convertString = @"";
        
    } else {
        convertString = [NSString stringWithCString:string encoding:NSUTF8StringEncoding];
    }
    
    return convertString;
}

char *_nhncloud_setApiData(const char *data) {
    NSString *message = stringWithCString(data);
    NHNCloudUnityMessage *unityMessage = [[NHNCloudUnityMessage alloc] initWithMessage:message];
    
    return [NHNCloudUnity didReceiveUnityMessage:unityMessage];
}
