var Deserializers = {}
Deserializers["UnityEngine.JointSpring"] = function (request, data, root) {
  var i1892 = root || request.c( 'UnityEngine.JointSpring' )
  var i1893 = data
  i1892.spring = i1893[0]
  i1892.damper = i1893[1]
  i1892.targetPosition = i1893[2]
  return i1892
}

Deserializers["UnityEngine.JointMotor"] = function (request, data, root) {
  var i1894 = root || request.c( 'UnityEngine.JointMotor' )
  var i1895 = data
  i1894.m_TargetVelocity = i1895[0]
  i1894.m_Force = i1895[1]
  i1894.m_FreeSpin = i1895[2]
  return i1894
}

Deserializers["UnityEngine.JointLimits"] = function (request, data, root) {
  var i1896 = root || request.c( 'UnityEngine.JointLimits' )
  var i1897 = data
  i1896.m_Min = i1897[0]
  i1896.m_Max = i1897[1]
  i1896.m_Bounciness = i1897[2]
  i1896.m_BounceMinVelocity = i1897[3]
  i1896.m_ContactDistance = i1897[4]
  i1896.minBounce = i1897[5]
  i1896.maxBounce = i1897[6]
  return i1896
}

Deserializers["UnityEngine.JointDrive"] = function (request, data, root) {
  var i1898 = root || request.c( 'UnityEngine.JointDrive' )
  var i1899 = data
  i1898.m_PositionSpring = i1899[0]
  i1898.m_PositionDamper = i1899[1]
  i1898.m_MaximumForce = i1899[2]
  i1898.m_UseAcceleration = i1899[3]
  return i1898
}

Deserializers["UnityEngine.SoftJointLimitSpring"] = function (request, data, root) {
  var i1900 = root || request.c( 'UnityEngine.SoftJointLimitSpring' )
  var i1901 = data
  i1900.m_Spring = i1901[0]
  i1900.m_Damper = i1901[1]
  return i1900
}

Deserializers["UnityEngine.SoftJointLimit"] = function (request, data, root) {
  var i1902 = root || request.c( 'UnityEngine.SoftJointLimit' )
  var i1903 = data
  i1902.m_Limit = i1903[0]
  i1902.m_Bounciness = i1903[1]
  i1902.m_ContactDistance = i1903[2]
  return i1902
}

Deserializers["UnityEngine.WheelFrictionCurve"] = function (request, data, root) {
  var i1904 = root || request.c( 'UnityEngine.WheelFrictionCurve' )
  var i1905 = data
  i1904.m_ExtremumSlip = i1905[0]
  i1904.m_ExtremumValue = i1905[1]
  i1904.m_AsymptoteSlip = i1905[2]
  i1904.m_AsymptoteValue = i1905[3]
  i1904.m_Stiffness = i1905[4]
  return i1904
}

Deserializers["UnityEngine.JointAngleLimits2D"] = function (request, data, root) {
  var i1906 = root || request.c( 'UnityEngine.JointAngleLimits2D' )
  var i1907 = data
  i1906.m_LowerAngle = i1907[0]
  i1906.m_UpperAngle = i1907[1]
  return i1906
}

Deserializers["UnityEngine.JointMotor2D"] = function (request, data, root) {
  var i1908 = root || request.c( 'UnityEngine.JointMotor2D' )
  var i1909 = data
  i1908.m_MotorSpeed = i1909[0]
  i1908.m_MaximumMotorTorque = i1909[1]
  return i1908
}

Deserializers["UnityEngine.JointSuspension2D"] = function (request, data, root) {
  var i1910 = root || request.c( 'UnityEngine.JointSuspension2D' )
  var i1911 = data
  i1910.m_DampingRatio = i1911[0]
  i1910.m_Frequency = i1911[1]
  i1910.m_Angle = i1911[2]
  return i1910
}

Deserializers["UnityEngine.JointTranslationLimits2D"] = function (request, data, root) {
  var i1912 = root || request.c( 'UnityEngine.JointTranslationLimits2D' )
  var i1913 = data
  i1912.m_LowerTranslation = i1913[0]
  i1912.m_UpperTranslation = i1913[1]
  return i1912
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material"] = function (request, data, root) {
  var i1914 = root || new pc.UnityMaterial()
  var i1915 = data
  i1914.name = i1915[0]
  request.r(i1915[1], i1915[2], 0, i1914, 'shader')
  i1914.renderQueue = i1915[3]
  i1914.enableInstancing = !!i1915[4]
  var i1917 = i1915[5]
  var i1916 = []
  for(var i = 0; i < i1917.length; i += 1) {
    i1916.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Material+FloatParameter', i1917[i + 0]) );
  }
  i1914.floatParameters = i1916
  var i1919 = i1915[6]
  var i1918 = []
  for(var i = 0; i < i1919.length; i += 1) {
    i1918.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Material+ColorParameter', i1919[i + 0]) );
  }
  i1914.colorParameters = i1918
  var i1921 = i1915[7]
  var i1920 = []
  for(var i = 0; i < i1921.length; i += 1) {
    i1920.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Material+VectorParameter', i1921[i + 0]) );
  }
  i1914.vectorParameters = i1920
  var i1923 = i1915[8]
  var i1922 = []
  for(var i = 0; i < i1923.length; i += 1) {
    i1922.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Material+TextureParameter', i1923[i + 0]) );
  }
  i1914.textureParameters = i1922
  var i1925 = i1915[9]
  var i1924 = []
  for(var i = 0; i < i1925.length; i += 1) {
    i1924.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Material+MaterialFlag', i1925[i + 0]) );
  }
  i1914.materialFlags = i1924
  return i1914
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material+FloatParameter"] = function (request, data, root) {
  var i1928 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Material+FloatParameter' )
  var i1929 = data
  i1928.name = i1929[0]
  i1928.value = i1929[1]
  return i1928
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material+ColorParameter"] = function (request, data, root) {
  var i1932 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Material+ColorParameter' )
  var i1933 = data
  i1932.name = i1933[0]
  i1932.value = new pc.Color(i1933[1], i1933[2], i1933[3], i1933[4])
  return i1932
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material+VectorParameter"] = function (request, data, root) {
  var i1936 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Material+VectorParameter' )
  var i1937 = data
  i1936.name = i1937[0]
  i1936.value = new pc.Vec4( i1937[1], i1937[2], i1937[3], i1937[4] )
  return i1936
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material+TextureParameter"] = function (request, data, root) {
  var i1940 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Material+TextureParameter' )
  var i1941 = data
  i1940.name = i1941[0]
  request.r(i1941[1], i1941[2], 0, i1940, 'value')
  return i1940
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material+MaterialFlag"] = function (request, data, root) {
  var i1944 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Material+MaterialFlag' )
  var i1945 = data
  i1944.name = i1945[0]
  i1944.enabled = !!i1945[1]
  return i1944
}

Deserializers["Luna.Unity.DTO.UnityEngine.Textures.Texture2D"] = function (request, data, root) {
  var i1946 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Textures.Texture2D' )
  var i1947 = data
  i1946.name = i1947[0]
  i1946.width = i1947[1]
  i1946.height = i1947[2]
  i1946.mipmapCount = i1947[3]
  i1946.anisoLevel = i1947[4]
  i1946.filterMode = i1947[5]
  i1946.hdr = !!i1947[6]
  i1946.format = i1947[7]
  i1946.wrapMode = i1947[8]
  i1946.alphaIsTransparency = !!i1947[9]
  i1946.alphaSource = i1947[10]
  i1946.graphicsFormat = i1947[11]
  i1946.sRGBTexture = !!i1947[12]
  i1946.desiredColorSpace = i1947[13]
  i1946.wrapU = i1947[14]
  i1946.wrapV = i1947[15]
  return i1946
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.Transform"] = function (request, data, root) {
  var i1948 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.Transform' )
  var i1949 = data
  i1948.position = new pc.Vec3( i1949[0], i1949[1], i1949[2] )
  i1948.scale = new pc.Vec3( i1949[3], i1949[4], i1949[5] )
  i1948.rotation = new pc.Quat(i1949[6], i1949[7], i1949[8], i1949[9])
  return i1948
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.SpriteRenderer"] = function (request, data, root) {
  var i1950 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.SpriteRenderer' )
  var i1951 = data
  i1950.color = new pc.Color(i1951[0], i1951[1], i1951[2], i1951[3])
  request.r(i1951[4], i1951[5], 0, i1950, 'sprite')
  i1950.flipX = !!i1951[6]
  i1950.flipY = !!i1951[7]
  i1950.drawMode = i1951[8]
  i1950.size = new pc.Vec2( i1951[9], i1951[10] )
  i1950.tileMode = i1951[11]
  i1950.adaptiveModeThreshold = i1951[12]
  i1950.maskInteraction = i1951[13]
  i1950.spriteSortPoint = i1951[14]
  i1950.enabled = !!i1951[15]
  request.r(i1951[16], i1951[17], 0, i1950, 'sharedMaterial')
  var i1953 = i1951[18]
  var i1952 = []
  for(var i = 0; i < i1953.length; i += 2) {
  request.r(i1953[i + 0], i1953[i + 1], 2, i1952, '')
  }
  i1950.sharedMaterials = i1952
  i1950.receiveShadows = !!i1951[19]
  i1950.shadowCastingMode = i1951[20]
  i1950.sortingLayerID = i1951[21]
  i1950.sortingOrder = i1951[22]
  i1950.lightmapIndex = i1951[23]
  i1950.lightmapSceneIndex = i1951[24]
  i1950.lightmapScaleOffset = new pc.Vec4( i1951[25], i1951[26], i1951[27], i1951[28] )
  i1950.lightProbeUsage = i1951[29]
  i1950.reflectionProbeUsage = i1951[30]
  return i1950
}

Deserializers["HighlightedZone"] = function (request, data, root) {
  var i1956 = root || request.c( 'HighlightedZone' )
  var i1957 = data
  return i1956
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.SortingGroup"] = function (request, data, root) {
  var i1958 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.SortingGroup' )
  var i1959 = data
  i1958.sortingLayerIndex = i1959[0]
  i1958.sortingOrder = i1959[1]
  i1958.sortingLayerName = i1959[2]
  i1958.enabled = !!i1959[3]
  return i1958
}

Deserializers["Luna.Unity.DTO.UnityEngine.Scene.GameObject"] = function (request, data, root) {
  var i1960 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Scene.GameObject' )
  var i1961 = data
  i1960.name = i1961[0]
  i1960.tagId = i1961[1]
  i1960.enabled = !!i1961[2]
  i1960.isStatic = !!i1961[3]
  i1960.layer = i1961[4]
  return i1960
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.ParticleSystemRenderer"] = function (request, data, root) {
  var i1962 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.ParticleSystemRenderer' )
  var i1963 = data
  request.r(i1963[0], i1963[1], 0, i1962, 'mesh')
  i1962.meshCount = i1963[2]
  i1962.activeVertexStreamsCount = i1963[3]
  i1962.alignment = i1963[4]
  i1962.renderMode = i1963[5]
  i1962.sortMode = i1963[6]
  i1962.lengthScale = i1963[7]
  i1962.velocityScale = i1963[8]
  i1962.cameraVelocityScale = i1963[9]
  i1962.normalDirection = i1963[10]
  i1962.sortingFudge = i1963[11]
  i1962.minParticleSize = i1963[12]
  i1962.maxParticleSize = i1963[13]
  i1962.pivot = new pc.Vec3( i1963[14], i1963[15], i1963[16] )
  request.r(i1963[17], i1963[18], 0, i1962, 'trailMaterial')
  i1962.applyActiveColorSpace = !!i1963[19]
  i1962.enabled = !!i1963[20]
  request.r(i1963[21], i1963[22], 0, i1962, 'sharedMaterial')
  var i1965 = i1963[23]
  var i1964 = []
  for(var i = 0; i < i1965.length; i += 2) {
  request.r(i1965[i + 0], i1965[i + 1], 2, i1964, '')
  }
  i1962.sharedMaterials = i1964
  i1962.receiveShadows = !!i1963[24]
  i1962.shadowCastingMode = i1963[25]
  i1962.sortingLayerID = i1963[26]
  i1962.sortingOrder = i1963[27]
  i1962.lightmapIndex = i1963[28]
  i1962.lightmapSceneIndex = i1963[29]
  i1962.lightmapScaleOffset = new pc.Vec4( i1963[30], i1963[31], i1963[32], i1963[33] )
  i1962.lightProbeUsage = i1963[34]
  i1962.reflectionProbeUsage = i1963[35]
  return i1962
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.ParticleSystem"] = function (request, data, root) {
  var i1966 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.ParticleSystem' )
  var i1967 = data
  i1966.main = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.MainModule', i1967[0], i1966.main)
  i1966.colorBySpeed = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ColorBySpeedModule', i1967[1], i1966.colorBySpeed)
  i1966.colorOverLifetime = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ColorOverLifetimeModule', i1967[2], i1966.colorOverLifetime)
  i1966.emission = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.EmissionModule', i1967[3], i1966.emission)
  i1966.rotationBySpeed = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.RotationBySpeedModule', i1967[4], i1966.rotationBySpeed)
  i1966.rotationOverLifetime = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.RotationOverLifetimeModule', i1967[5], i1966.rotationOverLifetime)
  i1966.shape = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ShapeModule', i1967[6], i1966.shape)
  i1966.sizeBySpeed = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.SizeBySpeedModule', i1967[7], i1966.sizeBySpeed)
  i1966.sizeOverLifetime = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.SizeOverLifetimeModule', i1967[8], i1966.sizeOverLifetime)
  i1966.textureSheetAnimation = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.TextureSheetAnimationModule', i1967[9], i1966.textureSheetAnimation)
  i1966.velocityOverLifetime = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.VelocityOverLifetimeModule', i1967[10], i1966.velocityOverLifetime)
  i1966.noise = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.NoiseModule', i1967[11], i1966.noise)
  i1966.inheritVelocity = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.InheritVelocityModule', i1967[12], i1966.inheritVelocity)
  i1966.forceOverLifetime = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ForceOverLifetimeModule', i1967[13], i1966.forceOverLifetime)
  i1966.limitVelocityOverLifetime = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.LimitVelocityOverLifetimeModule', i1967[14], i1966.limitVelocityOverLifetime)
  i1966.useAutoRandomSeed = !!i1967[15]
  i1966.randomSeed = i1967[16]
  return i1966
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.MainModule"] = function (request, data, root) {
  var i1968 = root || new pc.ParticleSystemMain()
  var i1969 = data
  i1968.duration = i1969[0]
  i1968.loop = !!i1969[1]
  i1968.prewarm = !!i1969[2]
  i1968.startDelay = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1969[3], i1968.startDelay)
  i1968.startLifetime = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1969[4], i1968.startLifetime)
  i1968.startSpeed = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1969[5], i1968.startSpeed)
  i1968.startSize3D = !!i1969[6]
  i1968.startSizeX = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1969[7], i1968.startSizeX)
  i1968.startSizeY = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1969[8], i1968.startSizeY)
  i1968.startSizeZ = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1969[9], i1968.startSizeZ)
  i1968.startRotation3D = !!i1969[10]
  i1968.startRotationX = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1969[11], i1968.startRotationX)
  i1968.startRotationY = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1969[12], i1968.startRotationY)
  i1968.startRotationZ = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1969[13], i1968.startRotationZ)
  i1968.startColor = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxGradient', i1969[14], i1968.startColor)
  i1968.gravityModifier = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1969[15], i1968.gravityModifier)
  i1968.simulationSpace = i1969[16]
  request.r(i1969[17], i1969[18], 0, i1968, 'customSimulationSpace')
  i1968.simulationSpeed = i1969[19]
  i1968.useUnscaledTime = !!i1969[20]
  i1968.scalingMode = i1969[21]
  i1968.playOnAwake = !!i1969[22]
  i1968.maxParticles = i1969[23]
  i1968.emitterVelocityMode = i1969[24]
  i1968.stopAction = i1969[25]
  return i1968
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve"] = function (request, data, root) {
  var i1970 = root || new pc.MinMaxCurve()
  var i1971 = data
  i1970.mode = i1971[0]
  i1970.curveMin = new pc.AnimationCurve( { keys_flow: i1971[1] } )
  i1970.curveMax = new pc.AnimationCurve( { keys_flow: i1971[2] } )
  i1970.curveMultiplier = i1971[3]
  i1970.constantMin = i1971[4]
  i1970.constantMax = i1971[5]
  return i1970
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxGradient"] = function (request, data, root) {
  var i1972 = root || new pc.MinMaxGradient()
  var i1973 = data
  i1972.mode = i1973[0]
  i1972.gradientMin = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Gradient', i1973[1], i1972.gradientMin)
  i1972.gradientMax = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Gradient', i1973[2], i1972.gradientMax)
  i1972.colorMin = new pc.Color(i1973[3], i1973[4], i1973[5], i1973[6])
  i1972.colorMax = new pc.Color(i1973[7], i1973[8], i1973[9], i1973[10])
  return i1972
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Gradient"] = function (request, data, root) {
  var i1974 = root || request.c( 'Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Gradient' )
  var i1975 = data
  i1974.mode = i1975[0]
  var i1977 = i1975[1]
  var i1976 = []
  for(var i = 0; i < i1977.length; i += 1) {
    i1976.push( request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Data.GradientColorKey', i1977[i + 0]) );
  }
  i1974.colorKeys = i1976
  var i1979 = i1975[2]
  var i1978 = []
  for(var i = 0; i < i1979.length; i += 1) {
    i1978.push( request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Data.GradientAlphaKey', i1979[i + 0]) );
  }
  i1974.alphaKeys = i1978
  return i1974
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ColorBySpeedModule"] = function (request, data, root) {
  var i1980 = root || new pc.ParticleSystemColorBySpeed()
  var i1981 = data
  i1980.enabled = !!i1981[0]
  i1980.color = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxGradient', i1981[1], i1980.color)
  i1980.range = new pc.Vec2( i1981[2], i1981[3] )
  return i1980
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Data.GradientColorKey"] = function (request, data, root) {
  var i1984 = root || request.c( 'Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Data.GradientColorKey' )
  var i1985 = data
  i1984.color = new pc.Color(i1985[0], i1985[1], i1985[2], i1985[3])
  i1984.time = i1985[4]
  return i1984
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Data.GradientAlphaKey"] = function (request, data, root) {
  var i1988 = root || request.c( 'Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Data.GradientAlphaKey' )
  var i1989 = data
  i1988.alpha = i1989[0]
  i1988.time = i1989[1]
  return i1988
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ColorOverLifetimeModule"] = function (request, data, root) {
  var i1990 = root || new pc.ParticleSystemColorOverLifetime()
  var i1991 = data
  i1990.enabled = !!i1991[0]
  i1990.color = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxGradient', i1991[1], i1990.color)
  return i1990
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.EmissionModule"] = function (request, data, root) {
  var i1992 = root || new pc.ParticleSystemEmitter()
  var i1993 = data
  i1992.enabled = !!i1993[0]
  i1992.rateOverTime = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1993[1], i1992.rateOverTime)
  i1992.rateOverDistance = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1993[2], i1992.rateOverDistance)
  var i1995 = i1993[3]
  var i1994 = []
  for(var i = 0; i < i1995.length; i += 1) {
    i1994.push( request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Burst', i1995[i + 0]) );
  }
  i1992.bursts = i1994
  return i1992
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Burst"] = function (request, data, root) {
  var i1998 = root || new pc.ParticleSystemBurst()
  var i1999 = data
  i1998.count = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1999[0], i1998.count)
  i1998.cycleCount = i1999[1]
  i1998.minCount = i1999[2]
  i1998.maxCount = i1999[3]
  i1998.repeatInterval = i1999[4]
  i1998.time = i1999[5]
  return i1998
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.RotationBySpeedModule"] = function (request, data, root) {
  var i2000 = root || new pc.ParticleSystemRotationBySpeed()
  var i2001 = data
  i2000.enabled = !!i2001[0]
  i2000.x = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2001[1], i2000.x)
  i2000.y = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2001[2], i2000.y)
  i2000.z = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2001[3], i2000.z)
  i2000.separateAxes = !!i2001[4]
  i2000.range = new pc.Vec2( i2001[5], i2001[6] )
  return i2000
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.RotationOverLifetimeModule"] = function (request, data, root) {
  var i2002 = root || new pc.ParticleSystemRotationOverLifetime()
  var i2003 = data
  i2002.enabled = !!i2003[0]
  i2002.x = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2003[1], i2002.x)
  i2002.y = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2003[2], i2002.y)
  i2002.z = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2003[3], i2002.z)
  i2002.separateAxes = !!i2003[4]
  return i2002
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ShapeModule"] = function (request, data, root) {
  var i2004 = root || new pc.ParticleSystemShape()
  var i2005 = data
  i2004.enabled = !!i2005[0]
  i2004.shapeType = i2005[1]
  i2004.randomDirectionAmount = i2005[2]
  i2004.sphericalDirectionAmount = i2005[3]
  i2004.randomPositionAmount = i2005[4]
  i2004.alignToDirection = !!i2005[5]
  i2004.radius = i2005[6]
  i2004.radiusMode = i2005[7]
  i2004.radiusSpread = i2005[8]
  i2004.radiusSpeed = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2005[9], i2004.radiusSpeed)
  i2004.radiusThickness = i2005[10]
  i2004.angle = i2005[11]
  i2004.length = i2005[12]
  i2004.boxThickness = new pc.Vec3( i2005[13], i2005[14], i2005[15] )
  i2004.meshShapeType = i2005[16]
  request.r(i2005[17], i2005[18], 0, i2004, 'mesh')
  request.r(i2005[19], i2005[20], 0, i2004, 'meshRenderer')
  request.r(i2005[21], i2005[22], 0, i2004, 'skinnedMeshRenderer')
  i2004.useMeshMaterialIndex = !!i2005[23]
  i2004.meshMaterialIndex = i2005[24]
  i2004.useMeshColors = !!i2005[25]
  i2004.normalOffset = i2005[26]
  i2004.arc = i2005[27]
  i2004.arcMode = i2005[28]
  i2004.arcSpread = i2005[29]
  i2004.arcSpeed = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2005[30], i2004.arcSpeed)
  i2004.donutRadius = i2005[31]
  i2004.position = new pc.Vec3( i2005[32], i2005[33], i2005[34] )
  i2004.rotation = new pc.Vec3( i2005[35], i2005[36], i2005[37] )
  i2004.scale = new pc.Vec3( i2005[38], i2005[39], i2005[40] )
  return i2004
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.SizeBySpeedModule"] = function (request, data, root) {
  var i2006 = root || new pc.ParticleSystemSizeBySpeed()
  var i2007 = data
  i2006.enabled = !!i2007[0]
  i2006.x = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2007[1], i2006.x)
  i2006.y = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2007[2], i2006.y)
  i2006.z = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2007[3], i2006.z)
  i2006.separateAxes = !!i2007[4]
  i2006.range = new pc.Vec2( i2007[5], i2007[6] )
  return i2006
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.SizeOverLifetimeModule"] = function (request, data, root) {
  var i2008 = root || new pc.ParticleSystemSizeOverLifetime()
  var i2009 = data
  i2008.enabled = !!i2009[0]
  i2008.x = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2009[1], i2008.x)
  i2008.y = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2009[2], i2008.y)
  i2008.z = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2009[3], i2008.z)
  i2008.separateAxes = !!i2009[4]
  return i2008
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.TextureSheetAnimationModule"] = function (request, data, root) {
  var i2010 = root || new pc.ParticleSystemTextureSheetAnimation()
  var i2011 = data
  i2010.enabled = !!i2011[0]
  i2010.mode = i2011[1]
  i2010.animation = i2011[2]
  i2010.numTilesX = i2011[3]
  i2010.numTilesY = i2011[4]
  i2010.useRandomRow = !!i2011[5]
  i2010.frameOverTime = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2011[6], i2010.frameOverTime)
  i2010.startFrame = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2011[7], i2010.startFrame)
  i2010.cycleCount = i2011[8]
  i2010.rowIndex = i2011[9]
  i2010.flipU = i2011[10]
  i2010.flipV = i2011[11]
  i2010.spriteCount = i2011[12]
  var i2013 = i2011[13]
  var i2012 = []
  for(var i = 0; i < i2013.length; i += 2) {
  request.r(i2013[i + 0], i2013[i + 1], 2, i2012, '')
  }
  i2010.sprites = i2012
  return i2010
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.VelocityOverLifetimeModule"] = function (request, data, root) {
  var i2016 = root || new pc.ParticleSystemVelocityOverLifetime()
  var i2017 = data
  i2016.enabled = !!i2017[0]
  i2016.x = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2017[1], i2016.x)
  i2016.y = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2017[2], i2016.y)
  i2016.z = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2017[3], i2016.z)
  i2016.radial = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2017[4], i2016.radial)
  i2016.speedModifier = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2017[5], i2016.speedModifier)
  i2016.space = i2017[6]
  i2016.orbitalX = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2017[7], i2016.orbitalX)
  i2016.orbitalY = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2017[8], i2016.orbitalY)
  i2016.orbitalZ = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2017[9], i2016.orbitalZ)
  i2016.orbitalOffsetX = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2017[10], i2016.orbitalOffsetX)
  i2016.orbitalOffsetY = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2017[11], i2016.orbitalOffsetY)
  i2016.orbitalOffsetZ = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2017[12], i2016.orbitalOffsetZ)
  return i2016
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.NoiseModule"] = function (request, data, root) {
  var i2018 = root || new pc.ParticleSystemNoise()
  var i2019 = data
  i2018.enabled = !!i2019[0]
  i2018.separateAxes = !!i2019[1]
  i2018.strengthX = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2019[2], i2018.strengthX)
  i2018.strengthY = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2019[3], i2018.strengthY)
  i2018.strengthZ = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2019[4], i2018.strengthZ)
  i2018.frequency = i2019[5]
  i2018.damping = !!i2019[6]
  i2018.octaveCount = i2019[7]
  i2018.octaveMultiplier = i2019[8]
  i2018.octaveScale = i2019[9]
  i2018.quality = i2019[10]
  i2018.scrollSpeed = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2019[11], i2018.scrollSpeed)
  i2018.scrollSpeedMultiplier = i2019[12]
  i2018.remapEnabled = !!i2019[13]
  i2018.remapX = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2019[14], i2018.remapX)
  i2018.remapY = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2019[15], i2018.remapY)
  i2018.remapZ = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2019[16], i2018.remapZ)
  i2018.positionAmount = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2019[17], i2018.positionAmount)
  i2018.rotationAmount = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2019[18], i2018.rotationAmount)
  i2018.sizeAmount = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2019[19], i2018.sizeAmount)
  return i2018
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.InheritVelocityModule"] = function (request, data, root) {
  var i2020 = root || new pc.ParticleSystemInheritVelocity()
  var i2021 = data
  i2020.enabled = !!i2021[0]
  i2020.mode = i2021[1]
  i2020.curve = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2021[2], i2020.curve)
  return i2020
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ForceOverLifetimeModule"] = function (request, data, root) {
  var i2022 = root || new pc.ParticleSystemForceOverLifetime()
  var i2023 = data
  i2022.enabled = !!i2023[0]
  i2022.x = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2023[1], i2022.x)
  i2022.y = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2023[2], i2022.y)
  i2022.z = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2023[3], i2022.z)
  i2022.space = i2023[4]
  i2022.randomized = !!i2023[5]
  return i2022
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.LimitVelocityOverLifetimeModule"] = function (request, data, root) {
  var i2024 = root || new pc.ParticleSystemLimitVelocityOverLifetime()
  var i2025 = data
  i2024.enabled = !!i2025[0]
  i2024.limit = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2025[1], i2024.limit)
  i2024.limitX = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2025[2], i2024.limitX)
  i2024.limitY = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2025[3], i2024.limitY)
  i2024.limitZ = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2025[4], i2024.limitZ)
  i2024.dampen = i2025[5]
  i2024.separateAxes = !!i2025[6]
  i2024.space = i2025[7]
  i2024.drag = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i2025[8], i2024.drag)
  i2024.multiplyDragByParticleSize = !!i2025[9]
  i2024.multiplyDragByParticleVelocity = !!i2025[10]
  return i2024
}

Deserializers["FogObject"] = function (request, data, root) {
  var i2026 = root || request.c( 'FogObject' )
  var i2027 = data
  i2026.m_revealDuration = i2027[0]
  i2026.m_hideDuration = i2027[1]
  request.r(i2027[2], i2027[3], 0, i2026, 'm_revealParticles')
  request.r(i2027[4], i2027[5], 0, i2026, 'm_hideParticles')
  request.r(i2027[6], i2027[7], 0, i2026, 'm_revealSound')
  request.r(i2027[8], i2027[9], 0, i2026, 'm_hideSound')
  request.r(i2027[10], i2027[11], 0, i2026, 'm_fogRenderer')
  i2026.m_moveDuration = i2027[12]
  return i2026
}

Deserializers["DragObject"] = function (request, data, root) {
  var i2028 = root || request.c( 'DragObject' )
  var i2029 = data
  request.r(i2029[0], i2029[1], 0, i2028, 'm_eggBasket')
  request.r(i2029[2], i2029[3], 0, i2028, 'm_indicatorObject')
  i2028.m_objectType = i2029[4]
  i2028.m_level = i2029[5]
  i2028.m_canBeMerged = !!i2029[6]
  i2028.m_mergeValue = i2029[7]
  i2028.m_mergeThreshold = i2029[8]
  i2028.m_canBeDragged = !!i2029[9]
  request.r(i2029[10], i2029[11], 0, i2028, 'm_objectCollider')
  i2028.m_nextLevelType = i2029[12]
  i2028.m_nextObjectCountToSpawn = i2029[13]
  i2028.m_moveDuration = i2029[14]
  i2028.m_pullDelta = i2029[15]
  i2028.m_pullTime = i2029[16]
  request.r(i2029[17], i2029[18], 0, i2028, 'm_spriteRenderer')
  i2028.m_height = i2029[19]
  i2028.m_duration = i2029[20]
  i2028.m_easeType = i2029[21]
  i2028.m_loops = i2029[22]
  i2028.m_loopType = i2029[23]
  i2028.m_isDragObjectBouncingInAir = !!i2029[24]
  i2028.m_isMergeOnPlace = !!i2029[25]
  i2028.m_isMergeThisObjectRevealFog = !!i2029[26]
  return i2028
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.BoxCollider2D"] = function (request, data, root) {
  var i2030 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.BoxCollider2D' )
  var i2031 = data
  i2030.usedByComposite = !!i2031[0]
  i2030.autoTiling = !!i2031[1]
  i2030.size = new pc.Vec2( i2031[2], i2031[3] )
  i2030.edgeRadius = i2031[4]
  i2030.enabled = !!i2031[5]
  i2030.isTrigger = !!i2031[6]
  i2030.usedByEffector = !!i2031[7]
  i2030.density = i2031[8]
  i2030.offset = new pc.Vec2( i2031[9], i2031[10] )
  request.r(i2031[11], i2031[12], 0, i2030, 'material')
  return i2030
}

Deserializers["EggBasket"] = function (request, data, root) {
  var i2032 = root || request.c( 'EggBasket' )
  var i2033 = data
  request.r(i2033[0], i2033[1], 0, i2032, 'm_thisDragObject')
  i2032.m_eggGenericId = i2033[2]
  i2032.m_eggCountToSpawn = i2033[3]
  var i2035 = i2033[4]
  var i2034 = []
  for(var i = 0; i < i2035.length; i += 2) {
    i2034.push( new pc.Vec2( i2035[i + 0], i2035[i + 1] ) );
  }
  i2032.m_spawnPositions = i2034
  return i2032
}

Deserializers["FlyableMergeObject"] = function (request, data, root) {
  var i2038 = root || request.c( 'FlyableMergeObject' )
  var i2039 = data
  request.r(i2039[0], i2039[1], 0, i2038, 'm_indicatorObject')
  i2038.m_pullDelta = i2039[2]
  i2038.m_pullTime = i2039[3]
  i2038.m_objectType = i2039[4]
  i2038.m_moveSpeed = i2039[5]
  i2038.m_delayBetweenMoves = i2039[6]
  i2038.m_mergeThreshold = i2039[7]
  request.r(i2039[8], i2039[9], 0, i2038, 'm_boxCollider2D')
  i2038.m_level = i2039[10]
  i2038.m_canBeMerged = !!i2039[11]
  i2038.m_nextLevelType = i2039[12]
  i2038.m_nextObjectCountToSpawn = i2039[13]
  return i2038
}

Deserializers["DecorationObject"] = function (request, data, root) {
  var i2040 = root || request.c( 'DecorationObject' )
  var i2041 = data
  i2040.m_objectType = i2041[0]
  return i2040
}

Deserializers["GridCell"] = function (request, data, root) {
  var i2042 = root || request.c( 'GridCell' )
  var i2043 = data
  request.r(i2043[0], i2043[1], 0, i2042, 'm_leftWall')
  request.r(i2043[2], i2043[3], 0, i2042, 'm_rightWall')
  request.r(i2043[4], i2043[5], 0, i2042, 'm_topWall')
  request.r(i2043[6], i2043[7], 0, i2042, 'm_bottomWall')
  request.r(i2043[8], i2043[9], 0, i2042, 'm_downSide_left')
  request.r(i2043[10], i2043[11], 0, i2042, 'm_downSide_down')
  return i2042
}

Deserializers["Luna.Unity.DTO.UnityEngine.Textures.Cubemap"] = function (request, data, root) {
  var i2044 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Textures.Cubemap' )
  var i2045 = data
  i2044.name = i2045[0]
  i2044.atlasId = i2045[1]
  i2044.mipmapCount = i2045[2]
  i2044.hdr = !!i2045[3]
  i2044.size = i2045[4]
  i2044.anisoLevel = i2045[5]
  i2044.filterMode = i2045[6]
  var i2047 = i2045[7]
  var i2046 = []
  for(var i = 0; i < i2047.length; i += 4) {
    i2046.push( UnityEngine.Rect.MinMaxRect(i2047[i + 0], i2047[i + 1], i2047[i + 2], i2047[i + 3]) );
  }
  i2044.rects = i2046
  i2044.wrapU = i2045[8]
  i2044.wrapV = i2045[9]
  return i2044
}

Deserializers["Luna.Unity.DTO.UnityEngine.Scene.Scene"] = function (request, data, root) {
  var i2050 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Scene.Scene' )
  var i2051 = data
  i2050.name = i2051[0]
  i2050.index = i2051[1]
  i2050.startup = !!i2051[2]
  return i2050
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.Camera"] = function (request, data, root) {
  var i2052 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.Camera' )
  var i2053 = data
  i2052.aspect = i2053[0]
  i2052.orthographic = !!i2053[1]
  i2052.orthographicSize = i2053[2]
  i2052.backgroundColor = new pc.Color(i2053[3], i2053[4], i2053[5], i2053[6])
  i2052.nearClipPlane = i2053[7]
  i2052.farClipPlane = i2053[8]
  i2052.fieldOfView = i2053[9]
  i2052.depth = i2053[10]
  i2052.clearFlags = i2053[11]
  i2052.cullingMask = i2053[12]
  i2052.rect = i2053[13]
  request.r(i2053[14], i2053[15], 0, i2052, 'targetTexture')
  i2052.usePhysicalProperties = !!i2053[16]
  i2052.focalLength = i2053[17]
  i2052.sensorSize = new pc.Vec2( i2053[18], i2053[19] )
  i2052.lensShift = new pc.Vec2( i2053[20], i2053[21] )
  i2052.gateFit = i2053[22]
  i2052.commandBufferCount = i2053[23]
  i2052.cameraType = i2053[24]
  i2052.enabled = !!i2053[25]
  return i2052
}

Deserializers["CameraController"] = function (request, data, root) {
  var i2054 = root || request.c( 'CameraController' )
  var i2055 = data
  request.r(i2055[0], i2055[1], 0, i2054, 'm_movingBounds')
  request.r(i2055[2], i2055[3], 0, i2054, 'm_initPoint')
  i2054.m_zoomMin = i2055[4]
  i2054.m_zoomMax = i2055[5]
  i2054.m_zoomSens = i2055[6]
  i2054.m_zoomSmooth = i2055[7]
  i2054.m_defaultZoom = i2055[8]
  i2054.m_movingSens = i2055[9]
  i2054.m_movingSmoothness = i2055[10]
  i2054.m_tapThreshold = i2055[11]
  i2054.m_inertiaSmoothness = i2055[12]
  i2054.m_initialInertiaModifier = i2055[13]
  i2054.m_canDrag = !!i2055[14]
  i2054.m_stopInertia = !!i2055[15]
  request.r(i2055[16], i2055[17], 0, i2054, 'm_mainCamera')
  i2054.m_zoomSpeed = i2055[18]
  i2054.m_zoomDifferenceLimits = new pc.Vec2( i2055[19], i2055[20] )
  return i2054
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.BoxCollider"] = function (request, data, root) {
  var i2056 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.BoxCollider' )
  var i2057 = data
  i2056.center = new pc.Vec3( i2057[0], i2057[1], i2057[2] )
  i2056.size = new pc.Vec3( i2057[3], i2057[4], i2057[5] )
  i2056.enabled = !!i2057[6]
  i2056.isTrigger = !!i2057[7]
  request.r(i2057[8], i2057[9], 0, i2056, 'material')
  return i2056
}

Deserializers["UnityEngine.EventSystems.EventSystem"] = function (request, data, root) {
  var i2058 = root || request.c( 'UnityEngine.EventSystems.EventSystem' )
  var i2059 = data
  request.r(i2059[0], i2059[1], 0, i2058, 'm_FirstSelected')
  i2058.m_sendNavigationEvents = !!i2059[2]
  i2058.m_DragThreshold = i2059[3]
  return i2058
}

Deserializers["UnityEngine.EventSystems.StandaloneInputModule"] = function (request, data, root) {
  var i2060 = root || request.c( 'UnityEngine.EventSystems.StandaloneInputModule' )
  var i2061 = data
  i2060.m_HorizontalAxis = i2061[0]
  i2060.m_VerticalAxis = i2061[1]
  i2060.m_SubmitButton = i2061[2]
  i2060.m_CancelButton = i2061[3]
  i2060.m_InputActionsPerSecond = i2061[4]
  i2060.m_RepeatDelay = i2061[5]
  i2060.m_ForceModuleActive = !!i2061[6]
  i2060.m_SendPointerHoverToParent = !!i2061[7]
  return i2060
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.RectTransform"] = function (request, data, root) {
  var i2062 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.RectTransform' )
  var i2063 = data
  i2062.pivot = new pc.Vec2( i2063[0], i2063[1] )
  i2062.anchorMin = new pc.Vec2( i2063[2], i2063[3] )
  i2062.anchorMax = new pc.Vec2( i2063[4], i2063[5] )
  i2062.sizeDelta = new pc.Vec2( i2063[6], i2063[7] )
  i2062.anchoredPosition3D = new pc.Vec3( i2063[8], i2063[9], i2063[10] )
  i2062.rotation = new pc.Quat(i2063[11], i2063[12], i2063[13], i2063[14])
  i2062.scale = new pc.Vec3( i2063[15], i2063[16], i2063[17] )
  return i2062
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.Canvas"] = function (request, data, root) {
  var i2064 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.Canvas' )
  var i2065 = data
  i2064.planeDistance = i2065[0]
  i2064.referencePixelsPerUnit = i2065[1]
  i2064.isFallbackOverlay = !!i2065[2]
  i2064.renderMode = i2065[3]
  i2064.renderOrder = i2065[4]
  i2064.sortingLayerName = i2065[5]
  i2064.sortingOrder = i2065[6]
  i2064.scaleFactor = i2065[7]
  request.r(i2065[8], i2065[9], 0, i2064, 'worldCamera')
  i2064.overrideSorting = !!i2065[10]
  i2064.pixelPerfect = !!i2065[11]
  i2064.targetDisplay = i2065[12]
  i2064.overridePixelPerfect = !!i2065[13]
  i2064.enabled = !!i2065[14]
  return i2064
}

Deserializers["UnityEngine.UI.CanvasScaler"] = function (request, data, root) {
  var i2066 = root || request.c( 'UnityEngine.UI.CanvasScaler' )
  var i2067 = data
  i2066.m_UiScaleMode = i2067[0]
  i2066.m_ReferencePixelsPerUnit = i2067[1]
  i2066.m_ScaleFactor = i2067[2]
  i2066.m_ReferenceResolution = new pc.Vec2( i2067[3], i2067[4] )
  i2066.m_ScreenMatchMode = i2067[5]
  i2066.m_MatchWidthOrHeight = i2067[6]
  i2066.m_PhysicalUnit = i2067[7]
  i2066.m_FallbackScreenDPI = i2067[8]
  i2066.m_DefaultSpriteDPI = i2067[9]
  i2066.m_DynamicPixelsPerUnit = i2067[10]
  i2066.m_PresetInfoIsWorld = !!i2067[11]
  return i2066
}

Deserializers["UnityEngine.UI.GraphicRaycaster"] = function (request, data, root) {
  var i2068 = root || request.c( 'UnityEngine.UI.GraphicRaycaster' )
  var i2069 = data
  i2068.m_IgnoreReversedGraphics = !!i2069[0]
  i2068.m_BlockingObjects = i2069[1]
  i2068.m_BlockingMask = UnityEngine.LayerMask.FromIntegerValue( i2069[2] )
  return i2068
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.CanvasRenderer"] = function (request, data, root) {
  var i2070 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.CanvasRenderer' )
  var i2071 = data
  i2070.cullTransparentMesh = !!i2071[0]
  return i2070
}

Deserializers["UnityEngine.UI.Image"] = function (request, data, root) {
  var i2072 = root || request.c( 'UnityEngine.UI.Image' )
  var i2073 = data
  request.r(i2073[0], i2073[1], 0, i2072, 'm_Sprite')
  i2072.m_Type = i2073[2]
  i2072.m_PreserveAspect = !!i2073[3]
  i2072.m_FillCenter = !!i2073[4]
  i2072.m_FillMethod = i2073[5]
  i2072.m_FillAmount = i2073[6]
  i2072.m_FillClockwise = !!i2073[7]
  i2072.m_FillOrigin = i2073[8]
  i2072.m_UseSpriteMesh = !!i2073[9]
  i2072.m_PixelsPerUnitMultiplier = i2073[10]
  request.r(i2073[11], i2073[12], 0, i2072, 'm_Material')
  i2072.m_Maskable = !!i2073[13]
  i2072.m_Color = new pc.Color(i2073[14], i2073[15], i2073[16], i2073[17])
  i2072.m_RaycastTarget = !!i2073[18]
  i2072.m_RaycastPadding = new pc.Vec4( i2073[19], i2073[20], i2073[21], i2073[22] )
  return i2072
}

Deserializers["TMPro.TextMeshProUGUI"] = function (request, data, root) {
  var i2074 = root || request.c( 'TMPro.TextMeshProUGUI' )
  var i2075 = data
  i2074.m_hasFontAssetChanged = !!i2075[0]
  request.r(i2075[1], i2075[2], 0, i2074, 'm_baseMaterial')
  i2074.m_maskOffset = new pc.Vec4( i2075[3], i2075[4], i2075[5], i2075[6] )
  i2074.m_text = i2075[7]
  i2074.m_isRightToLeft = !!i2075[8]
  request.r(i2075[9], i2075[10], 0, i2074, 'm_fontAsset')
  request.r(i2075[11], i2075[12], 0, i2074, 'm_sharedMaterial')
  var i2077 = i2075[13]
  var i2076 = []
  for(var i = 0; i < i2077.length; i += 2) {
  request.r(i2077[i + 0], i2077[i + 1], 2, i2076, '')
  }
  i2074.m_fontSharedMaterials = i2076
  request.r(i2075[14], i2075[15], 0, i2074, 'm_fontMaterial')
  var i2079 = i2075[16]
  var i2078 = []
  for(var i = 0; i < i2079.length; i += 2) {
  request.r(i2079[i + 0], i2079[i + 1], 2, i2078, '')
  }
  i2074.m_fontMaterials = i2078
  i2074.m_fontColor32 = UnityEngine.Color32.ConstructColor(i2075[17], i2075[18], i2075[19], i2075[20])
  i2074.m_fontColor = new pc.Color(i2075[21], i2075[22], i2075[23], i2075[24])
  i2074.m_enableVertexGradient = !!i2075[25]
  i2074.m_colorMode = i2075[26]
  i2074.m_fontColorGradient = request.d('TMPro.VertexGradient', i2075[27], i2074.m_fontColorGradient)
  request.r(i2075[28], i2075[29], 0, i2074, 'm_fontColorGradientPreset')
  request.r(i2075[30], i2075[31], 0, i2074, 'm_spriteAsset')
  i2074.m_tintAllSprites = !!i2075[32]
  request.r(i2075[33], i2075[34], 0, i2074, 'm_StyleSheet')
  i2074.m_TextStyleHashCode = i2075[35]
  i2074.m_overrideHtmlColors = !!i2075[36]
  i2074.m_faceColor = UnityEngine.Color32.ConstructColor(i2075[37], i2075[38], i2075[39], i2075[40])
  i2074.m_fontSize = i2075[41]
  i2074.m_fontSizeBase = i2075[42]
  i2074.m_fontWeight = i2075[43]
  i2074.m_enableAutoSizing = !!i2075[44]
  i2074.m_fontSizeMin = i2075[45]
  i2074.m_fontSizeMax = i2075[46]
  i2074.m_fontStyle = i2075[47]
  i2074.m_HorizontalAlignment = i2075[48]
  i2074.m_VerticalAlignment = i2075[49]
  i2074.m_textAlignment = i2075[50]
  i2074.m_characterSpacing = i2075[51]
  i2074.m_characterHorizontalScale = i2075[52]
  i2074.m_wordSpacing = i2075[53]
  i2074.m_lineSpacing = i2075[54]
  i2074.m_lineSpacingMax = i2075[55]
  i2074.m_paragraphSpacing = i2075[56]
  i2074.m_charWidthMaxAdj = i2075[57]
  i2074.m_TextWrappingMode = i2075[58]
  i2074.m_wordWrappingRatios = i2075[59]
  i2074.m_overflowMode = i2075[60]
  request.r(i2075[61], i2075[62], 0, i2074, 'm_linkedTextComponent')
  request.r(i2075[63], i2075[64], 0, i2074, 'parentLinkedComponent')
  i2074.m_enableKerning = !!i2075[65]
  var i2081 = i2075[66]
  var i2080 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.TextCore.OTL_FeatureTag')))
  for(var i = 0; i < i2081.length; i += 1) {
    i2080.add(i2081[i + 0]);
  }
  i2074.m_ActiveFontFeatures = i2080
  i2074.m_enableExtraPadding = !!i2075[67]
  i2074.checkPaddingRequired = !!i2075[68]
  i2074.m_isRichText = !!i2075[69]
  i2074.m_parseCtrlCharacters = !!i2075[70]
  i2074.m_isOrthographic = !!i2075[71]
  i2074.m_isCullingEnabled = !!i2075[72]
  i2074.m_horizontalMapping = i2075[73]
  i2074.m_verticalMapping = i2075[74]
  i2074.m_uvLineOffset = i2075[75]
  i2074.m_geometrySortingOrder = i2075[76]
  i2074.m_IsTextObjectScaleStatic = !!i2075[77]
  i2074.m_VertexBufferAutoSizeReduction = !!i2075[78]
  i2074.m_useMaxVisibleDescender = !!i2075[79]
  i2074.m_pageToDisplay = i2075[80]
  i2074.m_margin = new pc.Vec4( i2075[81], i2075[82], i2075[83], i2075[84] )
  i2074.m_isUsingLegacyAnimationComponent = !!i2075[85]
  i2074.m_isVolumetricText = !!i2075[86]
  request.r(i2075[87], i2075[88], 0, i2074, 'm_Material')
  i2074.m_EmojiFallbackSupport = !!i2075[89]
  i2074.m_Maskable = !!i2075[90]
  i2074.m_Color = new pc.Color(i2075[91], i2075[92], i2075[93], i2075[94])
  i2074.m_RaycastTarget = !!i2075[95]
  i2074.m_RaycastPadding = new pc.Vec4( i2075[96], i2075[97], i2075[98], i2075[99] )
  return i2074
}

Deserializers["TMPro.VertexGradient"] = function (request, data, root) {
  var i2082 = root || request.c( 'TMPro.VertexGradient' )
  var i2083 = data
  i2082.topLeft = new pc.Color(i2083[0], i2083[1], i2083[2], i2083[3])
  i2082.topRight = new pc.Color(i2083[4], i2083[5], i2083[6], i2083[7])
  i2082.bottomLeft = new pc.Color(i2083[8], i2083[9], i2083[10], i2083[11])
  i2082.bottomRight = new pc.Color(i2083[12], i2083[13], i2083[14], i2083[15])
  return i2082
}

Deserializers["UnityEngine.UI.Button"] = function (request, data, root) {
  var i2086 = root || request.c( 'UnityEngine.UI.Button' )
  var i2087 = data
  i2086.m_OnClick = request.d('UnityEngine.UI.Button+ButtonClickedEvent', i2087[0], i2086.m_OnClick)
  i2086.m_Navigation = request.d('UnityEngine.UI.Navigation', i2087[1], i2086.m_Navigation)
  i2086.m_Transition = i2087[2]
  i2086.m_Colors = request.d('UnityEngine.UI.ColorBlock', i2087[3], i2086.m_Colors)
  i2086.m_SpriteState = request.d('UnityEngine.UI.SpriteState', i2087[4], i2086.m_SpriteState)
  i2086.m_AnimationTriggers = request.d('UnityEngine.UI.AnimationTriggers', i2087[5], i2086.m_AnimationTriggers)
  i2086.m_Interactable = !!i2087[6]
  request.r(i2087[7], i2087[8], 0, i2086, 'm_TargetGraphic')
  return i2086
}

Deserializers["UnityEngine.UI.Button+ButtonClickedEvent"] = function (request, data, root) {
  var i2088 = root || request.c( 'UnityEngine.UI.Button+ButtonClickedEvent' )
  var i2089 = data
  i2088.m_PersistentCalls = request.d('UnityEngine.Events.PersistentCallGroup', i2089[0], i2088.m_PersistentCalls)
  return i2088
}

Deserializers["UnityEngine.Events.PersistentCallGroup"] = function (request, data, root) {
  var i2090 = root || request.c( 'UnityEngine.Events.PersistentCallGroup' )
  var i2091 = data
  var i2093 = i2091[0]
  var i2092 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.Events.PersistentCall')))
  for(var i = 0; i < i2093.length; i += 1) {
    i2092.add(request.d('UnityEngine.Events.PersistentCall', i2093[i + 0]));
  }
  i2090.m_Calls = i2092
  return i2090
}

Deserializers["UnityEngine.Events.PersistentCall"] = function (request, data, root) {
  var i2096 = root || request.c( 'UnityEngine.Events.PersistentCall' )
  var i2097 = data
  request.r(i2097[0], i2097[1], 0, i2096, 'm_Target')
  i2096.m_TargetAssemblyTypeName = i2097[2]
  i2096.m_MethodName = i2097[3]
  i2096.m_Mode = i2097[4]
  i2096.m_Arguments = request.d('UnityEngine.Events.ArgumentCache', i2097[5], i2096.m_Arguments)
  i2096.m_CallState = i2097[6]
  return i2096
}

Deserializers["UnityEngine.UI.Navigation"] = function (request, data, root) {
  var i2098 = root || request.c( 'UnityEngine.UI.Navigation' )
  var i2099 = data
  i2098.m_Mode = i2099[0]
  i2098.m_WrapAround = !!i2099[1]
  request.r(i2099[2], i2099[3], 0, i2098, 'm_SelectOnUp')
  request.r(i2099[4], i2099[5], 0, i2098, 'm_SelectOnDown')
  request.r(i2099[6], i2099[7], 0, i2098, 'm_SelectOnLeft')
  request.r(i2099[8], i2099[9], 0, i2098, 'm_SelectOnRight')
  return i2098
}

Deserializers["UnityEngine.UI.ColorBlock"] = function (request, data, root) {
  var i2100 = root || request.c( 'UnityEngine.UI.ColorBlock' )
  var i2101 = data
  i2100.m_NormalColor = new pc.Color(i2101[0], i2101[1], i2101[2], i2101[3])
  i2100.m_HighlightedColor = new pc.Color(i2101[4], i2101[5], i2101[6], i2101[7])
  i2100.m_PressedColor = new pc.Color(i2101[8], i2101[9], i2101[10], i2101[11])
  i2100.m_SelectedColor = new pc.Color(i2101[12], i2101[13], i2101[14], i2101[15])
  i2100.m_DisabledColor = new pc.Color(i2101[16], i2101[17], i2101[18], i2101[19])
  i2100.m_ColorMultiplier = i2101[20]
  i2100.m_FadeDuration = i2101[21]
  return i2100
}

Deserializers["UnityEngine.UI.SpriteState"] = function (request, data, root) {
  var i2102 = root || request.c( 'UnityEngine.UI.SpriteState' )
  var i2103 = data
  request.r(i2103[0], i2103[1], 0, i2102, 'm_HighlightedSprite')
  request.r(i2103[2], i2103[3], 0, i2102, 'm_PressedSprite')
  request.r(i2103[4], i2103[5], 0, i2102, 'm_SelectedSprite')
  request.r(i2103[6], i2103[7], 0, i2102, 'm_DisabledSprite')
  return i2102
}

Deserializers["UnityEngine.UI.AnimationTriggers"] = function (request, data, root) {
  var i2104 = root || request.c( 'UnityEngine.UI.AnimationTriggers' )
  var i2105 = data
  i2104.m_NormalTrigger = i2105[0]
  i2104.m_HighlightedTrigger = i2105[1]
  i2104.m_PressedTrigger = i2105[2]
  i2104.m_SelectedTrigger = i2105[3]
  i2104.m_DisabledTrigger = i2105[4]
  return i2104
}

Deserializers["TutorialHandPointer"] = function (request, data, root) {
  var i2106 = root || request.c( 'TutorialHandPointer' )
  var i2107 = data
  request.r(i2107[0], i2107[1], 0, i2106, 'm_spriteHand')
  i2106.m_startedColor = new pc.Color(i2107[2], i2107[3], i2107[4], i2107[5])
  i2106.m_alphaColor = new pc.Color(i2107[6], i2107[7], i2107[8], i2107[9])
  return i2106
}

Deserializers["DinoCarousel"] = function (request, data, root) {
  var i2108 = root || request.c( 'DinoCarousel' )
  var i2109 = data
  var i2111 = i2109[0]
  var i2110 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.UI.Image')))
  for(var i = 0; i < i2111.length; i += 2) {
  request.r(i2111[i + 0], i2111[i + 1], 1, i2110, '')
  }
  i2108.m_entitiesSprites = i2110
  i2108.m_animationDuration = i2109[1]
  i2108.m_slideDistance = i2109[2]
  i2108.m_easeType = i2109[3]
  i2108.m_startedSpritePosition = new pc.Vec2( i2109[4], i2109[5] )
  i2108.m_startedColor = new pc.Color(i2109[6], i2109[7], i2109[8], i2109[9])
  request.r(i2109[10], i2109[11], 0, i2108, 'm_frameImage')
  request.r(i2109[12], i2109[13], 0, i2108, 'm_mirrorImage')
  request.r(i2109[14], i2109[15], 0, i2108, 'm_gameObjectLeftArrow')
  request.r(i2109[16], i2109[17], 0, i2108, 'm_gameObjectRightArrow')
  return i2108
}

Deserializers["PlayNowButton"] = function (request, data, root) {
  var i2114 = root || request.c( 'PlayNowButton' )
  var i2115 = data
  i2114.m_scaleUpFactor = i2115[0]
  i2114.m_scaleDuration = i2115[1]
  i2114.m_easeType = i2115[2]
  request.r(i2115[3], i2115[4], 0, i2114, 'm_goToStoreButton')
  return i2114
}

Deserializers["UnityEngine.UI.AspectRatioFitter"] = function (request, data, root) {
  var i2116 = root || request.c( 'UnityEngine.UI.AspectRatioFitter' )
  var i2117 = data
  i2116.m_AspectMode = i2117[0]
  i2116.m_AspectRatio = i2117[1]
  return i2116
}

Deserializers["TutorialHand"] = function (request, data, root) {
  var i2118 = root || request.c( 'TutorialHand' )
  var i2119 = data
  request.r(i2119[0], i2119[1], 0, i2118, 'm_spriteRenderer')
  request.r(i2119[2], i2119[3], 0, i2118, 'm_objectManager')
  i2118.m_playerInactivityForTutorial = i2119[4]
  return i2118
}

Deserializers["FogManager"] = function (request, data, root) {
  var i2120 = root || request.c( 'FogManager' )
  var i2121 = data
  request.r(i2121[0], i2121[1], 0, i2120, 'm_fogObjectPrefab')
  var i2123 = i2121[2]
  var i2122 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.Vector2Int')))
  for(var i = 0; i < i2123.length; i += 2) {
    i2122.add(new pc.Vec2( i2123[i + 0], i2123[i + 1] ));
  }
  i2120.m_revealFogCoordinatesStep1 = i2122
  var i2125 = i2121[3]
  var i2124 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.Vector2Int')))
  for(var i = 0; i < i2125.length; i += 2) {
    i2124.add(new pc.Vec2( i2125[i + 0], i2125[i + 1] ));
  }
  i2120.m_revealFogCoordinatesStep2 = i2124
  return i2120
}

Deserializers["MapFogLayoutManager"] = function (request, data, root) {
  var i2128 = root || request.c( 'MapFogLayoutManager' )
  var i2129 = data
  i2128.m_mapLayout = request.d('MapFogLayoutManager+MapFogLayout', i2129[0], i2128.m_mapLayout)
  return i2128
}

Deserializers["MapFogLayoutManager+MapFogLayout"] = function (request, data, root) {
  var i2130 = root || request.c( 'MapFogLayoutManager+MapFogLayout' )
  var i2131 = data
  var i2133 = i2131[0]
  var i2132 = new (System.Collections.Generic.List$1(Bridge.ns('MapFogLayoutManager+CellFogData')))
  for(var i = 0; i < i2133.length; i += 1) {
    i2132.add(request.d('MapFogLayoutManager+CellFogData', i2133[i + 0]));
  }
  i2130.m_cellData = i2132
  return i2130
}

Deserializers["MapFogLayoutManager+CellFogData"] = function (request, data, root) {
  var i2136 = root || request.c( 'MapFogLayoutManager+CellFogData' )
  var i2137 = data
  i2136.x = i2137[0]
  i2136.y = i2137[1]
  return i2136
}

Deserializers["ObjectManager"] = function (request, data, root) {
  var i2138 = root || request.c( 'ObjectManager' )
  var i2139 = data
  var i2141 = i2139[0]
  var i2140 = new (System.Collections.Generic.List$1(Bridge.ns('DragObject')))
  for(var i = 0; i < i2141.length; i += 2) {
  request.r(i2141[i + 0], i2141[i + 1], 1, i2140, '')
  }
  i2138.m_matchObjectPrefabs = i2140
  var i2143 = i2139[1]
  var i2142 = new (System.Collections.Generic.List$1(Bridge.ns('FlyableMergeObject')))
  for(var i = 0; i < i2143.length; i += 2) {
  request.r(i2143[i + 0], i2143[i + 1], 1, i2142, '')
  }
  i2138.m_flyableObjectPrefabs = i2142
  var i2145 = i2139[2]
  var i2144 = new (System.Collections.Generic.List$1(Bridge.ns('DecorationObject')))
  for(var i = 0; i < i2145.length; i += 2) {
  request.r(i2145[i + 0], i2145[i + 1], 1, i2144, '')
  }
  i2138.m_decorationObjects = i2144
  request.r(i2139[3], i2139[4], 0, i2138, 'm_pointsManager')
  request.r(i2139[5], i2139[6], 0, i2138, 'm_tapTextTutorial')
  return i2138
}

Deserializers["MapObjectLayoutManager"] = function (request, data, root) {
  var i2152 = root || request.c( 'MapObjectLayoutManager' )
  var i2153 = data
  i2152.m_mapLayout = request.d('MapObjectLayoutManager+MapObjectLayout', i2153[0], i2152.m_mapLayout)
  return i2152
}

Deserializers["MapObjectLayoutManager+MapObjectLayout"] = function (request, data, root) {
  var i2154 = root || request.c( 'MapObjectLayoutManager+MapObjectLayout' )
  var i2155 = data
  var i2157 = i2155[0]
  var i2156 = new (System.Collections.Generic.List$1(Bridge.ns('MapObjectLayoutManager+CellObjectData')))
  for(var i = 0; i < i2157.length; i += 1) {
    i2156.add(request.d('MapObjectLayoutManager+CellObjectData', i2157[i + 0]));
  }
  i2154.m_cellData = i2156
  return i2154
}

Deserializers["MapObjectLayoutManager+CellObjectData"] = function (request, data, root) {
  var i2160 = root || request.c( 'MapObjectLayoutManager+CellObjectData' )
  var i2161 = data
  i2160.x = i2161[0]
  i2160.y = i2161[1]
  i2160.objectType = i2161[2]
  return i2160
}

Deserializers["MainSystem"] = function (request, data, root) {
  var i2162 = root || request.c( 'MainSystem' )
  var i2163 = data
  i2162.m_widthInCells = i2163[0]
  i2162.m_heightInCells = i2163[1]
  i2162.m_gridMode = i2163[2]
  request.r(i2163[3], i2163[4], 0, i2162, 'm_customShape')
  request.r(i2163[5], i2163[6], 0, i2162, 'm_lightPrefab')
  request.r(i2163[7], i2163[8], 0, i2162, 'm_darkPrefab')
  request.r(i2163[9], i2163[10], 0, i2162, 'm_fogManager')
  request.r(i2163[11], i2163[12], 0, i2162, 'm_mapObjectLayoutManager')
  request.r(i2163[13], i2163[14], 0, i2162, 'm_mapFogLayoutManager')
  request.r(i2163[15], i2163[16], 0, i2162, 'm_objectManager')
  request.r(i2163[17], i2163[18], 0, i2162, 'm_pointsManager')
  return i2162
}

Deserializers["FlyingObjectsManager"] = function (request, data, root) {
  var i2164 = root || request.c( 'FlyingObjectsManager' )
  var i2165 = data
  request.r(i2165[0], i2165[1], 0, i2164, 'm_flyingPrincess1LevelPrefab')
  i2164.flyingPrincess1LevelCount = i2165[2]
  request.r(i2165[3], i2165[4], 0, i2164, 'm_flyingPrincess2LevelPrefab')
  i2164.flyingPrincess2LevelCount = i2165[5]
  return i2164
}

Deserializers["PointsManager"] = function (request, data, root) {
  var i2166 = root || request.c( 'PointsManager' )
  var i2167 = data
  i2166.m_pointsCount = i2167[0]
  request.r(i2167[1], i2167[2], 0, i2166, 'm_flyingObjectManager')
  return i2166
}

Deserializers["DragManager"] = function (request, data, root) {
  var i2168 = root || request.c( 'DragManager' )
  var i2169 = data
  i2168.m_snapDistance = i2169[0]
  request.r(i2169[1], i2169[2], 0, i2168, 'm_highlightedZone')
  request.r(i2169[3], i2169[4], 0, i2168, 'm_pointsManager')
  request.r(i2169[5], i2169[6], 0, i2168, 'm_mergeEffectParticleSystem')
  request.r(i2169[7], i2169[8], 0, i2168, 'm_objectManager')
  request.r(i2169[9], i2169[10], 0, i2168, 'm_tutorialHand')
  request.r(i2169[11], i2169[12], 0, i2168, 'm_flyingObjectsManager')
  request.r(i2169[13], i2169[14], 0, i2168, 'm_fogManager')
  request.r(i2169[15], i2169[16], 0, i2168, 'm_mergeText')
  request.r(i2169[17], i2169[18], 0, i2168, 'm_dinoSelectionManager')
  return i2168
}

Deserializers["FlyingDragManager"] = function (request, data, root) {
  var i2170 = root || request.c( 'FlyingDragManager' )
  var i2171 = data
  i2170.m_snapDistance = i2171[0]
  i2170.mergeRadius = i2171[1]
  i2170.pullSpeed = i2171[2]
  request.r(i2171[3], i2171[4], 0, i2170, 'm_highlightedZone')
  request.r(i2171[5], i2171[6], 0, i2170, 'm_flyingObjectsManager')
  request.r(i2171[7], i2171[8], 0, i2170, 'm_mergeEffectParticleSystem')
  request.r(i2171[9], i2171[10], 0, i2170, 'm_pointsManager')
  return i2170
}

Deserializers["DinoSelectionManager"] = function (request, data, root) {
  var i2172 = root || request.c( 'DinoSelectionManager' )
  var i2173 = data
  request.r(i2173[0], i2173[1], 0, i2172, 'm_mainSystem')
  request.r(i2173[2], i2173[3], 0, i2172, 'm_cameraController')
  request.r(i2173[4], i2173[5], 0, i2172, 'm_choosingScreenOverlay')
  request.r(i2173[6], i2173[7], 0, i2172, 'm_dinoCarousel')
  request.r(i2173[8], i2173[9], 0, i2172, 'm_heartEffect')
  request.r(i2173[10], i2173[11], 0, i2172, 'm_chosenDinoPosition')
  request.r(i2173[12], i2173[13], 0, i2172, 'm_logoPlayNowButton')
  request.r(i2173[14], i2173[15], 0, i2172, 'm_logoPlayNowNewButtonPosition')
  request.r(i2173[16], i2173[17], 0, i2172, 'm_nextDinoButton')
  request.r(i2173[18], i2173[19], 0, i2172, 'm_previousDinoButton')
  request.r(i2173[20], i2173[21], 0, i2172, 'm_chooseDinoButton')
  request.r(i2173[22], i2173[23], 0, i2172, 'm_tutorialHandChooseButton')
  request.r(i2173[24], i2173[25], 0, i2172, 'm_arrowHandTutorial')
  request.r(i2173[26], i2173[27], 0, i2172, 'm_choosingScreenWorldCanvas')
  request.r(i2173[28], i2173[29], 0, i2172, 'm_mapObjectLayoutManager')
  var i2175 = i2173[30]
  var i2174 = new (System.Collections.Generic.List$1(Bridge.ns('ObjectSet')))
  for(var i = 0; i < i2175.length; i += 2) {
  request.r(i2175[i + 0], i2175[i + 1], 1, i2174, '')
  }
  i2172.m_dinoObjectSets = i2174
  request.r(i2173[31], i2173[32], 0, i2172, 'm_rewardCard')
  request.r(i2173[33], i2173[34], 0, i2172, 'm_rewardCardImage')
  request.r(i2173[35], i2173[36], 0, i2172, 'm_carouselGroup')
  return i2172
}

Deserializers["AudioSystem"] = function (request, data, root) {
  var i2178 = root || request.c( 'AudioSystem' )
  var i2179 = data
  request.r(i2179[0], i2179[1], 0, i2178, 'musicAudioSource')
  request.r(i2179[2], i2179[3], 0, i2178, 'soundFXAudioSource1')
  request.r(i2179[4], i2179[5], 0, i2178, 'soundFXAudioSource2')
  request.r(i2179[6], i2179[7], 0, i2178, 'm_mergeSoundClip')
  request.r(i2179[8], i2179[9], 0, i2178, 'm_chooseClip')
  request.r(i2179[10], i2179[11], 0, i2178, 'm_fogDissolveClip')
  request.r(i2179[12], i2179[13], 0, i2178, 'm_bubbleClip')
  request.r(i2179[14], i2179[15], 0, i2178, 'm_starSoundClip')
  return i2178
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.AudioSource"] = function (request, data, root) {
  var i2180 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.AudioSource' )
  var i2181 = data
  request.r(i2181[0], i2181[1], 0, i2180, 'clip')
  request.r(i2181[2], i2181[3], 0, i2180, 'outputAudioMixerGroup')
  i2180.playOnAwake = !!i2181[4]
  i2180.loop = !!i2181[5]
  i2180.time = i2181[6]
  i2180.volume = i2181[7]
  i2180.pitch = i2181[8]
  i2180.enabled = !!i2181[9]
  return i2180
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.RenderSettings"] = function (request, data, root) {
  var i2182 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.RenderSettings' )
  var i2183 = data
  i2182.ambientIntensity = i2183[0]
  i2182.reflectionIntensity = i2183[1]
  i2182.ambientMode = i2183[2]
  i2182.ambientLight = new pc.Color(i2183[3], i2183[4], i2183[5], i2183[6])
  i2182.ambientSkyColor = new pc.Color(i2183[7], i2183[8], i2183[9], i2183[10])
  i2182.ambientGroundColor = new pc.Color(i2183[11], i2183[12], i2183[13], i2183[14])
  i2182.ambientEquatorColor = new pc.Color(i2183[15], i2183[16], i2183[17], i2183[18])
  i2182.fogColor = new pc.Color(i2183[19], i2183[20], i2183[21], i2183[22])
  i2182.fogEndDistance = i2183[23]
  i2182.fogStartDistance = i2183[24]
  i2182.fogDensity = i2183[25]
  i2182.fog = !!i2183[26]
  request.r(i2183[27], i2183[28], 0, i2182, 'skybox')
  i2182.fogMode = i2183[29]
  var i2185 = i2183[30]
  var i2184 = []
  for(var i = 0; i < i2185.length; i += 1) {
    i2184.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+Lightmap', i2185[i + 0]) );
  }
  i2182.lightmaps = i2184
  i2182.lightProbes = request.d('Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+LightProbes', i2183[31], i2182.lightProbes)
  i2182.lightmapsMode = i2183[32]
  i2182.mixedBakeMode = i2183[33]
  i2182.environmentLightingMode = i2183[34]
  i2182.ambientProbe = new pc.SphericalHarmonicsL2(i2183[35])
  request.r(i2183[36], i2183[37], 0, i2182, 'customReflection')
  request.r(i2183[38], i2183[39], 0, i2182, 'defaultReflection')
  i2182.defaultReflectionMode = i2183[40]
  i2182.defaultReflectionResolution = i2183[41]
  i2182.sunLightObjectId = i2183[42]
  i2182.pixelLightCount = i2183[43]
  i2182.defaultReflectionHDR = !!i2183[44]
  i2182.hasLightDataAsset = !!i2183[45]
  i2182.hasManualGenerate = !!i2183[46]
  return i2182
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+Lightmap"] = function (request, data, root) {
  var i2188 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+Lightmap' )
  var i2189 = data
  request.r(i2189[0], i2189[1], 0, i2188, 'lightmapColor')
  request.r(i2189[2], i2189[3], 0, i2188, 'lightmapDirection')
  request.r(i2189[4], i2189[5], 0, i2188, 'shadowMask')
  return i2188
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+LightProbes"] = function (request, data, root) {
  var i2190 = root || new UnityEngine.LightProbes()
  var i2191 = data
  return i2190
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerCanvas"] = function (request, data, root) {
  var i2198 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerCanvas' )
  var i2199 = data
  request.r(i2199[0], i2199[1], 0, i2198, 'panelPrefab')
  var i2201 = i2199[2]
  var i2200 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.Rendering.UI.DebugUIPrefabBundle')))
  for(var i = 0; i < i2201.length; i += 1) {
    i2200.add(request.d('UnityEngine.Rendering.UI.DebugUIPrefabBundle', i2201[i + 0]));
  }
  i2198.prefabs = i2200
  return i2198
}

Deserializers["UnityEngine.Rendering.UI.DebugUIPrefabBundle"] = function (request, data, root) {
  var i2204 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIPrefabBundle' )
  var i2205 = data
  i2204.type = i2205[0]
  request.r(i2205[1], i2205[2], 0, i2204, 'prefab')
  return i2204
}

Deserializers["UnityEngine.UI.VerticalLayoutGroup"] = function (request, data, root) {
  var i2206 = root || request.c( 'UnityEngine.UI.VerticalLayoutGroup' )
  var i2207 = data
  i2206.m_Spacing = i2207[0]
  i2206.m_ChildForceExpandWidth = !!i2207[1]
  i2206.m_ChildForceExpandHeight = !!i2207[2]
  i2206.m_ChildControlWidth = !!i2207[3]
  i2206.m_ChildControlHeight = !!i2207[4]
  i2206.m_ChildScaleWidth = !!i2207[5]
  i2206.m_ChildScaleHeight = !!i2207[6]
  i2206.m_ReverseArrangement = !!i2207[7]
  i2206.m_Padding = UnityEngine.RectOffset.FromPaddings(i2207[8], i2207[9], i2207[10], i2207[11])
  i2206.m_ChildAlignment = i2207[12]
  return i2206
}

Deserializers["UnityEngine.UI.ContentSizeFitter"] = function (request, data, root) {
  var i2208 = root || request.c( 'UnityEngine.UI.ContentSizeFitter' )
  var i2209 = data
  i2208.m_HorizontalFit = i2209[0]
  i2208.m_VerticalFit = i2209[1]
  return i2208
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerContainer"] = function (request, data, root) {
  var i2210 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerContainer' )
  var i2211 = data
  request.r(i2211[0], i2211[1], 0, i2210, 'contentHolder')
  return i2210
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerPanel"] = function (request, data, root) {
  var i2212 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerPanel' )
  var i2213 = data
  request.r(i2213[0], i2213[1], 0, i2212, 'nameLabel')
  request.r(i2213[2], i2213[3], 0, i2212, 'scrollRect')
  request.r(i2213[4], i2213[5], 0, i2212, 'viewport')
  request.r(i2213[6], i2213[7], 0, i2212, 'Canvas')
  return i2212
}

Deserializers["UnityEngine.UI.LayoutElement"] = function (request, data, root) {
  var i2214 = root || request.c( 'UnityEngine.UI.LayoutElement' )
  var i2215 = data
  i2214.m_IgnoreLayout = !!i2215[0]
  i2214.m_MinWidth = i2215[1]
  i2214.m_MinHeight = i2215[2]
  i2214.m_PreferredWidth = i2215[3]
  i2214.m_PreferredHeight = i2215[4]
  i2214.m_FlexibleWidth = i2215[5]
  i2214.m_FlexibleHeight = i2215[6]
  i2214.m_LayoutPriority = i2215[7]
  return i2214
}

Deserializers["UnityEngine.Events.ArgumentCache"] = function (request, data, root) {
  var i2216 = root || request.c( 'UnityEngine.Events.ArgumentCache' )
  var i2217 = data
  request.r(i2217[0], i2217[1], 0, i2216, 'm_ObjectArgument')
  i2216.m_ObjectArgumentAssemblyTypeName = i2217[2]
  i2216.m_IntArgument = i2217[3]
  i2216.m_FloatArgument = i2217[4]
  i2216.m_StringArgument = i2217[5]
  i2216.m_BoolArgument = !!i2217[6]
  return i2216
}

Deserializers["UnityEngine.UI.Text"] = function (request, data, root) {
  var i2218 = root || request.c( 'UnityEngine.UI.Text' )
  var i2219 = data
  i2218.m_FontData = request.d('UnityEngine.UI.FontData', i2219[0], i2218.m_FontData)
  i2218.m_Text = i2219[1]
  request.r(i2219[2], i2219[3], 0, i2218, 'm_Material')
  i2218.m_Maskable = !!i2219[4]
  i2218.m_Color = new pc.Color(i2219[5], i2219[6], i2219[7], i2219[8])
  i2218.m_RaycastTarget = !!i2219[9]
  i2218.m_RaycastPadding = new pc.Vec4( i2219[10], i2219[11], i2219[12], i2219[13] )
  return i2218
}

Deserializers["UnityEngine.UI.FontData"] = function (request, data, root) {
  var i2220 = root || request.c( 'UnityEngine.UI.FontData' )
  var i2221 = data
  request.r(i2221[0], i2221[1], 0, i2220, 'm_Font')
  i2220.m_FontSize = i2221[2]
  i2220.m_FontStyle = i2221[3]
  i2220.m_BestFit = !!i2221[4]
  i2220.m_MinSize = i2221[5]
  i2220.m_MaxSize = i2221[6]
  i2220.m_Alignment = i2221[7]
  i2220.m_AlignByGeometry = !!i2221[8]
  i2220.m_RichText = !!i2221[9]
  i2220.m_HorizontalOverflow = i2221[10]
  i2220.m_VerticalOverflow = i2221[11]
  i2220.m_LineSpacing = i2221[12]
  return i2220
}

Deserializers["UnityEngine.UI.ScrollRect"] = function (request, data, root) {
  var i2222 = root || request.c( 'UnityEngine.UI.ScrollRect' )
  var i2223 = data
  request.r(i2223[0], i2223[1], 0, i2222, 'm_Content')
  i2222.m_Horizontal = !!i2223[2]
  i2222.m_Vertical = !!i2223[3]
  i2222.m_MovementType = i2223[4]
  i2222.m_Elasticity = i2223[5]
  i2222.m_Inertia = !!i2223[6]
  i2222.m_DecelerationRate = i2223[7]
  i2222.m_ScrollSensitivity = i2223[8]
  request.r(i2223[9], i2223[10], 0, i2222, 'm_Viewport')
  request.r(i2223[11], i2223[12], 0, i2222, 'm_HorizontalScrollbar')
  request.r(i2223[13], i2223[14], 0, i2222, 'm_VerticalScrollbar')
  i2222.m_HorizontalScrollbarVisibility = i2223[15]
  i2222.m_VerticalScrollbarVisibility = i2223[16]
  i2222.m_HorizontalScrollbarSpacing = i2223[17]
  i2222.m_VerticalScrollbarSpacing = i2223[18]
  i2222.m_OnValueChanged = request.d('UnityEngine.UI.ScrollRect+ScrollRectEvent', i2223[19], i2222.m_OnValueChanged)
  return i2222
}

Deserializers["UnityEngine.UI.ScrollRect+ScrollRectEvent"] = function (request, data, root) {
  var i2224 = root || request.c( 'UnityEngine.UI.ScrollRect+ScrollRectEvent' )
  var i2225 = data
  i2224.m_PersistentCalls = request.d('UnityEngine.Events.PersistentCallGroup', i2225[0], i2224.m_PersistentCalls)
  return i2224
}

Deserializers["UnityEngine.UI.Mask"] = function (request, data, root) {
  var i2226 = root || request.c( 'UnityEngine.UI.Mask' )
  var i2227 = data
  i2226.m_ShowMaskGraphic = !!i2227[0]
  return i2226
}

Deserializers["UnityEngine.UI.Scrollbar"] = function (request, data, root) {
  var i2228 = root || request.c( 'UnityEngine.UI.Scrollbar' )
  var i2229 = data
  request.r(i2229[0], i2229[1], 0, i2228, 'm_HandleRect')
  i2228.m_Direction = i2229[2]
  i2228.m_Value = i2229[3]
  i2228.m_Size = i2229[4]
  i2228.m_NumberOfSteps = i2229[5]
  i2228.m_OnValueChanged = request.d('UnityEngine.UI.Scrollbar+ScrollEvent', i2229[6], i2228.m_OnValueChanged)
  i2228.m_Navigation = request.d('UnityEngine.UI.Navigation', i2229[7], i2228.m_Navigation)
  i2228.m_Transition = i2229[8]
  i2228.m_Colors = request.d('UnityEngine.UI.ColorBlock', i2229[9], i2228.m_Colors)
  i2228.m_SpriteState = request.d('UnityEngine.UI.SpriteState', i2229[10], i2228.m_SpriteState)
  i2228.m_AnimationTriggers = request.d('UnityEngine.UI.AnimationTriggers', i2229[11], i2228.m_AnimationTriggers)
  i2228.m_Interactable = !!i2229[12]
  request.r(i2229[13], i2229[14], 0, i2228, 'm_TargetGraphic')
  return i2228
}

Deserializers["UnityEngine.UI.Scrollbar+ScrollEvent"] = function (request, data, root) {
  var i2230 = root || request.c( 'UnityEngine.UI.Scrollbar+ScrollEvent' )
  var i2231 = data
  i2230.m_PersistentCalls = request.d('UnityEngine.Events.PersistentCallGroup', i2231[0], i2230.m_PersistentCalls)
  return i2230
}

Deserializers["UnityEngine.EventSystems.EventTrigger"] = function (request, data, root) {
  var i2232 = root || request.c( 'UnityEngine.EventSystems.EventTrigger' )
  var i2233 = data
  var i2235 = i2233[0]
  var i2234 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.EventSystems.EventTrigger+Entry')))
  for(var i = 0; i < i2235.length; i += 1) {
    i2234.add(request.d('UnityEngine.EventSystems.EventTrigger+Entry', i2235[i + 0]));
  }
  i2232.m_Delegates = i2234
  return i2232
}

Deserializers["UnityEngine.EventSystems.EventTrigger+Entry"] = function (request, data, root) {
  var i2238 = root || request.c( 'UnityEngine.EventSystems.EventTrigger+Entry' )
  var i2239 = data
  i2238.eventID = i2239[0]
  i2238.callback = request.d('UnityEngine.EventSystems.EventTrigger+TriggerEvent', i2239[1], i2238.callback)
  return i2238
}

Deserializers["UnityEngine.EventSystems.EventTrigger+TriggerEvent"] = function (request, data, root) {
  var i2240 = root || request.c( 'UnityEngine.EventSystems.EventTrigger+TriggerEvent' )
  var i2241 = data
  i2240.m_PersistentCalls = request.d('UnityEngine.Events.PersistentCallGroup', i2241[0], i2240.m_PersistentCalls)
  return i2240
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerValue"] = function (request, data, root) {
  var i2242 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerValue' )
  var i2243 = data
  request.r(i2243[0], i2243[1], 0, i2242, 'nameLabel')
  request.r(i2243[2], i2243[3], 0, i2242, 'valueLabel')
  i2242.colorDefault = new pc.Color(i2243[4], i2243[5], i2243[6], i2243[7])
  i2242.colorSelected = new pc.Color(i2243[8], i2243[9], i2243[10], i2243[11])
  return i2242
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerToggle"] = function (request, data, root) {
  var i2244 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerToggle' )
  var i2245 = data
  request.r(i2245[0], i2245[1], 0, i2244, 'nameLabel')
  request.r(i2245[2], i2245[3], 0, i2244, 'valueToggle')
  request.r(i2245[4], i2245[5], 0, i2244, 'checkmarkImage')
  i2244.colorDefault = new pc.Color(i2245[6], i2245[7], i2245[8], i2245[9])
  i2244.colorSelected = new pc.Color(i2245[10], i2245[11], i2245[12], i2245[13])
  return i2244
}

Deserializers["UnityEngine.UI.Toggle"] = function (request, data, root) {
  var i2246 = root || request.c( 'UnityEngine.UI.Toggle' )
  var i2247 = data
  i2246.toggleTransition = i2247[0]
  request.r(i2247[1], i2247[2], 0, i2246, 'graphic')
  i2246.onValueChanged = request.d('UnityEngine.UI.Toggle+ToggleEvent', i2247[3], i2246.onValueChanged)
  request.r(i2247[4], i2247[5], 0, i2246, 'm_Group')
  i2246.m_IsOn = !!i2247[6]
  i2246.m_Navigation = request.d('UnityEngine.UI.Navigation', i2247[7], i2246.m_Navigation)
  i2246.m_Transition = i2247[8]
  i2246.m_Colors = request.d('UnityEngine.UI.ColorBlock', i2247[9], i2246.m_Colors)
  i2246.m_SpriteState = request.d('UnityEngine.UI.SpriteState', i2247[10], i2246.m_SpriteState)
  i2246.m_AnimationTriggers = request.d('UnityEngine.UI.AnimationTriggers', i2247[11], i2246.m_AnimationTriggers)
  i2246.m_Interactable = !!i2247[12]
  request.r(i2247[13], i2247[14], 0, i2246, 'm_TargetGraphic')
  return i2246
}

Deserializers["UnityEngine.UI.Toggle+ToggleEvent"] = function (request, data, root) {
  var i2248 = root || request.c( 'UnityEngine.UI.Toggle+ToggleEvent' )
  var i2249 = data
  i2248.m_PersistentCalls = request.d('UnityEngine.Events.PersistentCallGroup', i2249[0], i2248.m_PersistentCalls)
  return i2248
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerIntField"] = function (request, data, root) {
  var i2250 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerIntField' )
  var i2251 = data
  request.r(i2251[0], i2251[1], 0, i2250, 'nameLabel')
  request.r(i2251[2], i2251[3], 0, i2250, 'valueLabel')
  i2250.colorDefault = new pc.Color(i2251[4], i2251[5], i2251[6], i2251[7])
  i2250.colorSelected = new pc.Color(i2251[8], i2251[9], i2251[10], i2251[11])
  return i2250
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerUIntField"] = function (request, data, root) {
  var i2252 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerUIntField' )
  var i2253 = data
  request.r(i2253[0], i2253[1], 0, i2252, 'nameLabel')
  request.r(i2253[2], i2253[3], 0, i2252, 'valueLabel')
  i2252.colorDefault = new pc.Color(i2253[4], i2253[5], i2253[6], i2253[7])
  i2252.colorSelected = new pc.Color(i2253[8], i2253[9], i2253[10], i2253[11])
  return i2252
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerFloatField"] = function (request, data, root) {
  var i2254 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerFloatField' )
  var i2255 = data
  request.r(i2255[0], i2255[1], 0, i2254, 'nameLabel')
  request.r(i2255[2], i2255[3], 0, i2254, 'valueLabel')
  i2254.colorDefault = new pc.Color(i2255[4], i2255[5], i2255[6], i2255[7])
  i2254.colorSelected = new pc.Color(i2255[8], i2255[9], i2255[10], i2255[11])
  return i2254
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerEnumField"] = function (request, data, root) {
  var i2256 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerEnumField' )
  var i2257 = data
  request.r(i2257[0], i2257[1], 0, i2256, 'nextButtonText')
  request.r(i2257[2], i2257[3], 0, i2256, 'previousButtonText')
  request.r(i2257[4], i2257[5], 0, i2256, 'nameLabel')
  request.r(i2257[6], i2257[7], 0, i2256, 'valueLabel')
  i2256.colorDefault = new pc.Color(i2257[8], i2257[9], i2257[10], i2257[11])
  i2256.colorSelected = new pc.Color(i2257[12], i2257[13], i2257[14], i2257[15])
  return i2256
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerButton"] = function (request, data, root) {
  var i2258 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerButton' )
  var i2259 = data
  request.r(i2259[0], i2259[1], 0, i2258, 'nameLabel')
  i2258.colorDefault = new pc.Color(i2259[2], i2259[3], i2259[4], i2259[5])
  i2258.colorSelected = new pc.Color(i2259[6], i2259[7], i2259[8], i2259[9])
  return i2258
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerFoldout"] = function (request, data, root) {
  var i2260 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerFoldout' )
  var i2261 = data
  request.r(i2261[0], i2261[1], 0, i2260, 'nameLabel')
  request.r(i2261[2], i2261[3], 0, i2260, 'valueToggle')
  i2260.colorDefault = new pc.Color(i2261[4], i2261[5], i2261[6], i2261[7])
  i2260.colorSelected = new pc.Color(i2261[8], i2261[9], i2261[10], i2261[11])
  return i2260
}

Deserializers["UnityEngine.Rendering.UI.UIFoldout"] = function (request, data, root) {
  var i2262 = root || request.c( 'UnityEngine.Rendering.UI.UIFoldout' )
  var i2263 = data
  request.r(i2263[0], i2263[1], 0, i2262, 'content')
  request.r(i2263[2], i2263[3], 0, i2262, 'arrowOpened')
  request.r(i2263[4], i2263[5], 0, i2262, 'arrowClosed')
  i2262.toggleTransition = i2263[6]
  request.r(i2263[7], i2263[8], 0, i2262, 'graphic')
  i2262.onValueChanged = request.d('UnityEngine.UI.Toggle+ToggleEvent', i2263[9], i2262.onValueChanged)
  request.r(i2263[10], i2263[11], 0, i2262, 'm_Group')
  i2262.m_IsOn = !!i2263[12]
  i2262.m_Navigation = request.d('UnityEngine.UI.Navigation', i2263[13], i2262.m_Navigation)
  i2262.m_Transition = i2263[14]
  i2262.m_Colors = request.d('UnityEngine.UI.ColorBlock', i2263[15], i2262.m_Colors)
  i2262.m_SpriteState = request.d('UnityEngine.UI.SpriteState', i2263[16], i2262.m_SpriteState)
  i2262.m_AnimationTriggers = request.d('UnityEngine.UI.AnimationTriggers', i2263[17], i2262.m_AnimationTriggers)
  i2262.m_Interactable = !!i2263[18]
  request.r(i2263[19], i2263[20], 0, i2262, 'm_TargetGraphic')
  return i2262
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerColor"] = function (request, data, root) {
  var i2264 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerColor' )
  var i2265 = data
  request.r(i2265[0], i2265[1], 0, i2264, 'nameLabel')
  request.r(i2265[2], i2265[3], 0, i2264, 'valueToggle')
  request.r(i2265[4], i2265[5], 0, i2264, 'colorImage')
  request.r(i2265[6], i2265[7], 0, i2264, 'fieldR')
  request.r(i2265[8], i2265[9], 0, i2264, 'fieldG')
  request.r(i2265[10], i2265[11], 0, i2264, 'fieldB')
  request.r(i2265[12], i2265[13], 0, i2264, 'fieldA')
  i2264.colorDefault = new pc.Color(i2265[14], i2265[15], i2265[16], i2265[17])
  i2264.colorSelected = new pc.Color(i2265[18], i2265[19], i2265[20], i2265[21])
  return i2264
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerIndirectFloatField"] = function (request, data, root) {
  var i2266 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerIndirectFloatField' )
  var i2267 = data
  request.r(i2267[0], i2267[1], 0, i2266, 'nameLabel')
  request.r(i2267[2], i2267[3], 0, i2266, 'valueLabel')
  i2266.colorDefault = new pc.Color(i2267[4], i2267[5], i2267[6], i2267[7])
  i2266.colorSelected = new pc.Color(i2267[8], i2267[9], i2267[10], i2267[11])
  return i2266
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerVector2"] = function (request, data, root) {
  var i2268 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerVector2' )
  var i2269 = data
  request.r(i2269[0], i2269[1], 0, i2268, 'nameLabel')
  request.r(i2269[2], i2269[3], 0, i2268, 'valueToggle')
  request.r(i2269[4], i2269[5], 0, i2268, 'fieldX')
  request.r(i2269[6], i2269[7], 0, i2268, 'fieldY')
  i2268.colorDefault = new pc.Color(i2269[8], i2269[9], i2269[10], i2269[11])
  i2268.colorSelected = new pc.Color(i2269[12], i2269[13], i2269[14], i2269[15])
  return i2268
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerVector3"] = function (request, data, root) {
  var i2270 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerVector3' )
  var i2271 = data
  request.r(i2271[0], i2271[1], 0, i2270, 'nameLabel')
  request.r(i2271[2], i2271[3], 0, i2270, 'valueToggle')
  request.r(i2271[4], i2271[5], 0, i2270, 'fieldX')
  request.r(i2271[6], i2271[7], 0, i2270, 'fieldY')
  request.r(i2271[8], i2271[9], 0, i2270, 'fieldZ')
  i2270.colorDefault = new pc.Color(i2271[10], i2271[11], i2271[12], i2271[13])
  i2270.colorSelected = new pc.Color(i2271[14], i2271[15], i2271[16], i2271[17])
  return i2270
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerVector4"] = function (request, data, root) {
  var i2272 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerVector4' )
  var i2273 = data
  request.r(i2273[0], i2273[1], 0, i2272, 'nameLabel')
  request.r(i2273[2], i2273[3], 0, i2272, 'valueToggle')
  request.r(i2273[4], i2273[5], 0, i2272, 'fieldX')
  request.r(i2273[6], i2273[7], 0, i2272, 'fieldY')
  request.r(i2273[8], i2273[9], 0, i2272, 'fieldZ')
  request.r(i2273[10], i2273[11], 0, i2272, 'fieldW')
  i2272.colorDefault = new pc.Color(i2273[12], i2273[13], i2273[14], i2273[15])
  i2272.colorSelected = new pc.Color(i2273[16], i2273[17], i2273[18], i2273[19])
  return i2272
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerVBox"] = function (request, data, root) {
  var i2274 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerVBox' )
  var i2275 = data
  i2274.colorDefault = new pc.Color(i2275[0], i2275[1], i2275[2], i2275[3])
  i2274.colorSelected = new pc.Color(i2275[4], i2275[5], i2275[6], i2275[7])
  return i2274
}

Deserializers["UnityEngine.UI.HorizontalLayoutGroup"] = function (request, data, root) {
  var i2276 = root || request.c( 'UnityEngine.UI.HorizontalLayoutGroup' )
  var i2277 = data
  i2276.m_Spacing = i2277[0]
  i2276.m_ChildForceExpandWidth = !!i2277[1]
  i2276.m_ChildForceExpandHeight = !!i2277[2]
  i2276.m_ChildControlWidth = !!i2277[3]
  i2276.m_ChildControlHeight = !!i2277[4]
  i2276.m_ChildScaleWidth = !!i2277[5]
  i2276.m_ChildScaleHeight = !!i2277[6]
  i2276.m_ReverseArrangement = !!i2277[7]
  i2276.m_Padding = UnityEngine.RectOffset.FromPaddings(i2277[8], i2277[9], i2277[10], i2277[11])
  i2276.m_ChildAlignment = i2277[12]
  return i2276
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerHBox"] = function (request, data, root) {
  var i2278 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerHBox' )
  var i2279 = data
  i2278.colorDefault = new pc.Color(i2279[0], i2279[1], i2279[2], i2279[3])
  i2278.colorSelected = new pc.Color(i2279[4], i2279[5], i2279[6], i2279[7])
  return i2278
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerGroup"] = function (request, data, root) {
  var i2280 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerGroup' )
  var i2281 = data
  request.r(i2281[0], i2281[1], 0, i2280, 'nameLabel')
  request.r(i2281[2], i2281[3], 0, i2280, 'header')
  i2280.colorDefault = new pc.Color(i2281[4], i2281[5], i2281[6], i2281[7])
  i2280.colorSelected = new pc.Color(i2281[8], i2281[9], i2281[10], i2281[11])
  return i2280
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerBitField"] = function (request, data, root) {
  var i2282 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerBitField' )
  var i2283 = data
  request.r(i2283[0], i2283[1], 0, i2282, 'nameLabel')
  request.r(i2283[2], i2283[3], 0, i2282, 'valueToggle')
  var i2285 = i2283[4]
  var i2284 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.Rendering.UI.DebugUIHandlerIndirectToggle')))
  for(var i = 0; i < i2285.length; i += 2) {
  request.r(i2285[i + 0], i2285[i + 1], 1, i2284, '')
  }
  i2282.toggles = i2284
  i2282.colorDefault = new pc.Color(i2283[5], i2283[6], i2283[7], i2283[8])
  i2282.colorSelected = new pc.Color(i2283[9], i2283[10], i2283[11], i2283[12])
  return i2282
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerIndirectToggle"] = function (request, data, root) {
  var i2288 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerIndirectToggle' )
  var i2289 = data
  request.r(i2289[0], i2289[1], 0, i2288, 'nameLabel')
  request.r(i2289[2], i2289[3], 0, i2288, 'valueToggle')
  request.r(i2289[4], i2289[5], 0, i2288, 'checkmarkImage')
  i2288.colorDefault = new pc.Color(i2289[6], i2289[7], i2289[8], i2289[9])
  i2288.colorSelected = new pc.Color(i2289[10], i2289[11], i2289[12], i2289[13])
  return i2288
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerToggleHistory"] = function (request, data, root) {
  var i2290 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerToggleHistory' )
  var i2291 = data
  request.r(i2291[0], i2291[1], 0, i2290, 'nameLabel')
  request.r(i2291[2], i2291[3], 0, i2290, 'valueToggle')
  request.r(i2291[4], i2291[5], 0, i2290, 'checkmarkImage')
  i2290.colorDefault = new pc.Color(i2291[6], i2291[7], i2291[8], i2291[9])
  i2290.colorSelected = new pc.Color(i2291[10], i2291[11], i2291[12], i2291[13])
  return i2290
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerEnumHistory"] = function (request, data, root) {
  var i2292 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerEnumHistory' )
  var i2293 = data
  request.r(i2293[0], i2293[1], 0, i2292, 'nextButtonText')
  request.r(i2293[2], i2293[3], 0, i2292, 'previousButtonText')
  request.r(i2293[4], i2293[5], 0, i2292, 'nameLabel')
  request.r(i2293[6], i2293[7], 0, i2292, 'valueLabel')
  i2292.colorDefault = new pc.Color(i2293[8], i2293[9], i2293[10], i2293[11])
  i2292.colorSelected = new pc.Color(i2293[12], i2293[13], i2293[14], i2293[15])
  return i2292
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerRow"] = function (request, data, root) {
  var i2294 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerRow' )
  var i2295 = data
  request.r(i2295[0], i2295[1], 0, i2294, 'nameLabel')
  request.r(i2295[2], i2295[3], 0, i2294, 'valueToggle')
  i2294.colorDefault = new pc.Color(i2295[4], i2295[5], i2295[6], i2295[7])
  i2294.colorSelected = new pc.Color(i2295[8], i2295[9], i2295[10], i2295[11])
  return i2294
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerMessageBox"] = function (request, data, root) {
  var i2296 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerMessageBox' )
  var i2297 = data
  request.r(i2297[0], i2297[1], 0, i2296, 'nameLabel')
  i2296.colorDefault = new pc.Color(i2297[2], i2297[3], i2297[4], i2297[5])
  i2296.colorSelected = new pc.Color(i2297[6], i2297[7], i2297[8], i2297[9])
  return i2296
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerProgressBar"] = function (request, data, root) {
  var i2298 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerProgressBar' )
  var i2299 = data
  request.r(i2299[0], i2299[1], 0, i2298, 'nameLabel')
  request.r(i2299[2], i2299[3], 0, i2298, 'valueLabel')
  request.r(i2299[4], i2299[5], 0, i2298, 'progressBarRect')
  i2298.colorDefault = new pc.Color(i2299[6], i2299[7], i2299[8], i2299[9])
  i2298.colorSelected = new pc.Color(i2299[10], i2299[11], i2299[12], i2299[13])
  return i2298
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerValueTuple"] = function (request, data, root) {
  var i2300 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerValueTuple' )
  var i2301 = data
  request.r(i2301[0], i2301[1], 0, i2300, 'nameLabel')
  request.r(i2301[2], i2301[3], 0, i2300, 'valueLabel')
  i2300.colorDefault = new pc.Color(i2301[4], i2301[5], i2301[6], i2301[7])
  i2300.colorSelected = new pc.Color(i2301[8], i2301[9], i2301[10], i2301[11])
  return i2300
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerObject"] = function (request, data, root) {
  var i2302 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerObject' )
  var i2303 = data
  request.r(i2303[0], i2303[1], 0, i2302, 'nameLabel')
  request.r(i2303[2], i2303[3], 0, i2302, 'valueLabel')
  i2302.colorDefault = new pc.Color(i2303[4], i2303[5], i2303[6], i2303[7])
  i2302.colorSelected = new pc.Color(i2303[8], i2303[9], i2303[10], i2303[11])
  return i2302
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerObjectList"] = function (request, data, root) {
  var i2304 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerObjectList' )
  var i2305 = data
  request.r(i2305[0], i2305[1], 0, i2304, 'nextButtonText')
  request.r(i2305[2], i2305[3], 0, i2304, 'previousButtonText')
  request.r(i2305[4], i2305[5], 0, i2304, 'nameLabel')
  request.r(i2305[6], i2305[7], 0, i2304, 'valueLabel')
  i2304.colorDefault = new pc.Color(i2305[8], i2305[9], i2305[10], i2305[11])
  i2304.colorSelected = new pc.Color(i2305[12], i2305[13], i2305[14], i2305[15])
  return i2304
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerObjectPopupField"] = function (request, data, root) {
  var i2306 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerObjectPopupField' )
  var i2307 = data
  request.r(i2307[0], i2307[1], 0, i2306, 'nextButtonText')
  request.r(i2307[2], i2307[3], 0, i2306, 'previousButtonText')
  request.r(i2307[4], i2307[5], 0, i2306, 'nameLabel')
  request.r(i2307[6], i2307[7], 0, i2306, 'valueLabel')
  i2306.colorDefault = new pc.Color(i2307[8], i2307[9], i2307[10], i2307[11])
  i2306.colorSelected = new pc.Color(i2307[12], i2307[13], i2307[14], i2307[15])
  return i2306
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerRenderingLayerField"] = function (request, data, root) {
  var i2308 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerRenderingLayerField' )
  var i2309 = data
  request.r(i2309[0], i2309[1], 0, i2308, 'nameLabel')
  request.r(i2309[2], i2309[3], 0, i2308, 'valueToggle')
  var i2311 = i2309[4]
  var i2310 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.Rendering.UI.DebugUIHandlerIndirectToggle')))
  for(var i = 0; i < i2311.length; i += 2) {
  request.r(i2311[i + 0], i2311[i + 1], 1, i2310, '')
  }
  i2308.toggles = i2310
  i2308.colorDefault = new pc.Color(i2309[5], i2309[6], i2309[7], i2309[8])
  i2308.colorSelected = new pc.Color(i2309[9], i2309[10], i2309[11], i2309[12])
  return i2308
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerPersistentCanvas"] = function (request, data, root) {
  var i2312 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerPersistentCanvas' )
  var i2313 = data
  request.r(i2313[0], i2313[1], 0, i2312, 'panel')
  request.r(i2313[2], i2313[3], 0, i2312, 'valuePrefab')
  return i2312
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.UniversalRenderPipelineAsset"] = function (request, data, root) {
  var i2314 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.UniversalRenderPipelineAsset' )
  var i2315 = data
  i2314.AdditionalLightsRenderingMode = i2315[0]
  i2314.LightRenderingMode = request.d('Luna.Unity.DTO.UnityEngine.Assets.LightRenderingMode', i2315[1], i2314.LightRenderingMode)
  i2314.MainLightRenderingModeValue = i2315[2]
  i2314.SupportsMainLightShadows = !!i2315[3]
  i2314.MixedLightingSupported = !!i2315[4]
  i2314.MainLightShadowmapResolutionValue = i2315[5]
  i2314.SupportsSoftShadows = !!i2315[6]
  i2314.SoftShadowQualityValue = i2315[7]
  i2314.ShadowDistance = i2315[8]
  i2314.ShadowCascadeCount = i2315[9]
  i2314.Cascade2Split = i2315[10]
  i2314.Cascade3Split = new pc.Vec2( i2315[11], i2315[12] )
  i2314.Cascade4Split = new pc.Vec3( i2315[13], i2315[14], i2315[15] )
  i2314.CascadeBorder = i2315[16]
  i2314.ShadowDepthBias = i2315[17]
  i2314.ShadowNormalBias = i2315[18]
  i2314.RequireDepthTexture = !!i2315[19]
  i2314.RequireOpaqueTexture = !!i2315[20]
  i2314.scriptableRendererData = request.d('Luna.Unity.DTO.UnityEngine.Assets.ScriptableRendererData', i2315[21], i2314.scriptableRendererData)
  return i2314
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.LightRenderingMode"] = function (request, data, root) {
  var i2316 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.LightRenderingMode' )
  var i2317 = data
  i2316.Disabled = i2317[0]
  i2316.PerVertex = i2317[1]
  i2316.PerPixel = i2317[2]
  return i2316
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ScriptableRendererData"] = function (request, data, root) {
  var i2318 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ScriptableRendererData' )
  var i2319 = data
  i2318.opaqueLayerMask = i2319[0]
  i2318.transparentLayerMask = i2319[1]
  var i2321 = i2319[2]
  var i2320 = []
  for(var i = 0; i < i2321.length; i += 1) {
    i2320.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.RenderObjects', i2321[i + 0]) );
  }
  i2318.RenderObjectsFeatures = i2320
  i2318.name = i2319[3]
  return i2318
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.RenderObjects"] = function (request, data, root) {
  var i2324 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.RenderObjects' )
  var i2325 = data
  i2324.settings = request.d('Luna.Unity.DTO.UnityEngine.Assets.RenderObjects+RenderObjectsSettings', i2325[0], i2324.settings)
  i2324.name = i2325[1]
  i2324.typeName = i2325[2]
  return i2324
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader"] = function (request, data, root) {
  var i2326 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader' )
  var i2327 = data
  var i2329 = i2327[0]
  var i2328 = new (System.Collections.Generic.List$1(Bridge.ns('Luna.Unity.DTO.UnityEngine.Assets.Shader+ShaderCompilationError')))
  for(var i = 0; i < i2329.length; i += 1) {
    i2328.add(request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+ShaderCompilationError', i2329[i + 0]));
  }
  i2326.ShaderCompilationErrors = i2328
  i2326.name = i2327[1]
  i2326.guid = i2327[2]
  var i2331 = i2327[3]
  var i2330 = []
  for(var i = 0; i < i2331.length; i += 1) {
    i2330.push( i2331[i + 0] );
  }
  i2326.shaderDefinedKeywords = i2330
  var i2333 = i2327[4]
  var i2332 = []
  for(var i = 0; i < i2333.length; i += 1) {
    i2332.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass', i2333[i + 0]) );
  }
  i2326.passes = i2332
  var i2335 = i2327[5]
  var i2334 = []
  for(var i = 0; i < i2335.length; i += 1) {
    i2334.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+UsePass', i2335[i + 0]) );
  }
  i2326.usePasses = i2334
  var i2337 = i2327[6]
  var i2336 = []
  for(var i = 0; i < i2337.length; i += 1) {
    i2336.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+DefaultParameterValue', i2337[i + 0]) );
  }
  i2326.defaultParameterValues = i2336
  request.r(i2327[7], i2327[8], 0, i2326, 'unityFallbackShader')
  i2326.readDepth = !!i2327[9]
  i2326.hasDepthOnlyPass = !!i2327[10]
  i2326.isCreatedByShaderGraph = !!i2327[11]
  i2326.disableBatching = !!i2327[12]
  i2326.compiled = !!i2327[13]
  return i2326
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+ShaderCompilationError"] = function (request, data, root) {
  var i2340 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+ShaderCompilationError' )
  var i2341 = data
  i2340.shaderName = i2341[0]
  i2340.errorMessage = i2341[1]
  return i2340
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass"] = function (request, data, root) {
  var i2346 = root || new pc.UnityShaderPass()
  var i2347 = data
  i2346.id = i2347[0]
  i2346.subShaderIndex = i2347[1]
  i2346.name = i2347[2]
  i2346.passType = i2347[3]
  i2346.grabPassTextureName = i2347[4]
  i2346.usePass = !!i2347[5]
  i2346.zTest = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i2347[6], i2346.zTest)
  i2346.zWrite = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i2347[7], i2346.zWrite)
  i2346.culling = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i2347[8], i2346.culling)
  i2346.blending = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Blending', i2347[9], i2346.blending)
  i2346.alphaBlending = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Blending', i2347[10], i2346.alphaBlending)
  i2346.colorWriteMask = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i2347[11], i2346.colorWriteMask)
  i2346.offsetUnits = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i2347[12], i2346.offsetUnits)
  i2346.offsetFactor = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i2347[13], i2346.offsetFactor)
  i2346.stencilRef = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i2347[14], i2346.stencilRef)
  i2346.stencilReadMask = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i2347[15], i2346.stencilReadMask)
  i2346.stencilWriteMask = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i2347[16], i2346.stencilWriteMask)
  i2346.stencilOp = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp', i2347[17], i2346.stencilOp)
  i2346.stencilOpFront = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp', i2347[18], i2346.stencilOpFront)
  i2346.stencilOpBack = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp', i2347[19], i2346.stencilOpBack)
  var i2349 = i2347[20]
  var i2348 = []
  for(var i = 0; i < i2349.length; i += 1) {
    i2348.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Tag', i2349[i + 0]) );
  }
  i2346.tags = i2348
  var i2351 = i2347[21]
  var i2350 = []
  for(var i = 0; i < i2351.length; i += 1) {
    i2350.push( i2351[i + 0] );
  }
  i2346.passDefinedKeywords = i2350
  var i2353 = i2347[22]
  var i2352 = []
  for(var i = 0; i < i2353.length; i += 1) {
    i2352.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+KeywordGroup', i2353[i + 0]) );
  }
  i2346.passDefinedKeywordGroups = i2352
  var i2355 = i2347[23]
  var i2354 = []
  for(var i = 0; i < i2355.length; i += 1) {
    i2354.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Variant', i2355[i + 0]) );
  }
  i2346.variants = i2354
  var i2357 = i2347[24]
  var i2356 = []
  for(var i = 0; i < i2357.length; i += 1) {
    i2356.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Variant', i2357[i + 0]) );
  }
  i2346.excludedVariants = i2356
  i2346.hasDepthReader = !!i2347[25]
  return i2346
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value"] = function (request, data, root) {
  var i2358 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value' )
  var i2359 = data
  i2358.val = i2359[0]
  i2358.name = i2359[1]
  return i2358
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Blending"] = function (request, data, root) {
  var i2360 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Blending' )
  var i2361 = data
  i2360.src = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i2361[0], i2360.src)
  i2360.dst = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i2361[1], i2360.dst)
  i2360.op = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i2361[2], i2360.op)
  return i2360
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp"] = function (request, data, root) {
  var i2362 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp' )
  var i2363 = data
  i2362.pass = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i2363[0], i2362.pass)
  i2362.fail = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i2363[1], i2362.fail)
  i2362.zFail = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i2363[2], i2362.zFail)
  i2362.comp = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i2363[3], i2362.comp)
  return i2362
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Tag"] = function (request, data, root) {
  var i2366 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Tag' )
  var i2367 = data
  i2366.name = i2367[0]
  i2366.value = i2367[1]
  return i2366
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+KeywordGroup"] = function (request, data, root) {
  var i2370 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+KeywordGroup' )
  var i2371 = data
  var i2373 = i2371[0]
  var i2372 = []
  for(var i = 0; i < i2373.length; i += 1) {
    i2372.push( i2373[i + 0] );
  }
  i2370.keywords = i2372
  i2370.hasDiscard = !!i2371[1]
  return i2370
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Variant"] = function (request, data, root) {
  var i2376 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Variant' )
  var i2377 = data
  i2376.passId = i2377[0]
  i2376.subShaderIndex = i2377[1]
  var i2379 = i2377[2]
  var i2378 = []
  for(var i = 0; i < i2379.length; i += 1) {
    i2378.push( i2379[i + 0] );
  }
  i2376.keywords = i2378
  i2376.vertexProgram = i2377[3]
  i2376.fragmentProgram = i2377[4]
  i2376.exportedForWebGl2 = !!i2377[5]
  i2376.readDepth = !!i2377[6]
  return i2376
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+UsePass"] = function (request, data, root) {
  var i2382 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+UsePass' )
  var i2383 = data
  request.r(i2383[0], i2383[1], 0, i2382, 'shader')
  i2382.pass = i2383[2]
  return i2382
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+DefaultParameterValue"] = function (request, data, root) {
  var i2386 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+DefaultParameterValue' )
  var i2387 = data
  i2386.name = i2387[0]
  i2386.type = i2387[1]
  i2386.value = new pc.Vec4( i2387[2], i2387[3], i2387[4], i2387[5] )
  i2386.textureValue = i2387[6]
  i2386.shaderPropertyFlag = i2387[7]
  return i2386
}

Deserializers["Luna.Unity.DTO.UnityEngine.Textures.Sprite"] = function (request, data, root) {
  var i2388 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Textures.Sprite' )
  var i2389 = data
  i2388.name = i2389[0]
  request.r(i2389[1], i2389[2], 0, i2388, 'texture')
  i2388.aabb = i2389[3]
  i2388.vertices = i2389[4]
  i2388.triangles = i2389[5]
  i2388.textureRect = UnityEngine.Rect.MinMaxRect(i2389[6], i2389[7], i2389[8], i2389[9])
  i2388.packedRect = UnityEngine.Rect.MinMaxRect(i2389[10], i2389[11], i2389[12], i2389[13])
  i2388.border = new pc.Vec4( i2389[14], i2389[15], i2389[16], i2389[17] )
  i2388.transparency = i2389[18]
  i2388.bounds = i2389[19]
  i2388.pixelsPerUnit = i2389[20]
  i2388.textureWidth = i2389[21]
  i2388.textureHeight = i2389[22]
  i2388.nativeSize = new pc.Vec2( i2389[23], i2389[24] )
  i2388.pivot = new pc.Vec2( i2389[25], i2389[26] )
  i2388.textureRectOffset = new pc.Vec2( i2389[27], i2389[28] )
  return i2388
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.AudioClip"] = function (request, data, root) {
  var i2390 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.AudioClip' )
  var i2391 = data
  i2390.name = i2391[0]
  return i2390
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Font"] = function (request, data, root) {
  var i2392 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Font' )
  var i2393 = data
  i2392.name = i2393[0]
  i2392.ascent = i2393[1]
  i2392.originalLineHeight = i2393[2]
  i2392.fontSize = i2393[3]
  var i2395 = i2393[4]
  var i2394 = []
  for(var i = 0; i < i2395.length; i += 1) {
    i2394.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Font+CharacterInfo', i2395[i + 0]) );
  }
  i2392.characterInfo = i2394
  request.r(i2393[5], i2393[6], 0, i2392, 'texture')
  i2392.originalFontSize = i2393[7]
  return i2392
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Font+CharacterInfo"] = function (request, data, root) {
  var i2398 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Font+CharacterInfo' )
  var i2399 = data
  i2398.index = i2399[0]
  i2398.advance = i2399[1]
  i2398.bearing = i2399[2]
  i2398.glyphWidth = i2399[3]
  i2398.glyphHeight = i2399[4]
  i2398.minX = i2399[5]
  i2398.maxX = i2399[6]
  i2398.minY = i2399[7]
  i2398.maxY = i2399[8]
  i2398.uvBottomLeftX = i2399[9]
  i2398.uvBottomLeftY = i2399[10]
  i2398.uvBottomRightX = i2399[11]
  i2398.uvBottomRightY = i2399[12]
  i2398.uvTopLeftX = i2399[13]
  i2398.uvTopLeftY = i2399[14]
  i2398.uvTopRightX = i2399[15]
  i2398.uvTopRightY = i2399[16]
  return i2398
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.TextAsset"] = function (request, data, root) {
  var i2400 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.TextAsset' )
  var i2401 = data
  i2400.name = i2401[0]
  i2400.bytes64 = i2401[1]
  i2400.data = i2401[2]
  return i2400
}

Deserializers["TMPro.TMP_FontAsset"] = function (request, data, root) {
  var i2402 = root || request.c( 'TMPro.TMP_FontAsset' )
  var i2403 = data
  i2402.normalStyle = i2403[0]
  i2402.normalSpacingOffset = i2403[1]
  i2402.boldStyle = i2403[2]
  i2402.boldSpacing = i2403[3]
  i2402.italicStyle = i2403[4]
  i2402.tabSize = i2403[5]
  request.r(i2403[6], i2403[7], 0, i2402, 'atlas')
  i2402.m_SourceFontFileGUID = i2403[8]
  i2402.m_CreationSettings = request.d('TMPro.FontAssetCreationSettings', i2403[9], i2402.m_CreationSettings)
  request.r(i2403[10], i2403[11], 0, i2402, 'm_SourceFontFile')
  i2402.m_SourceFontFilePath = i2403[12]
  i2402.m_AtlasPopulationMode = i2403[13]
  i2402.InternalDynamicOS = !!i2403[14]
  var i2405 = i2403[15]
  var i2404 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.TextCore.Glyph')))
  for(var i = 0; i < i2405.length; i += 1) {
    i2404.add(request.d('UnityEngine.TextCore.Glyph', i2405[i + 0]));
  }
  i2402.m_GlyphTable = i2404
  var i2407 = i2403[16]
  var i2406 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_Character')))
  for(var i = 0; i < i2407.length; i += 1) {
    i2406.add(request.d('TMPro.TMP_Character', i2407[i + 0]));
  }
  i2402.m_CharacterTable = i2406
  var i2409 = i2403[17]
  var i2408 = []
  for(var i = 0; i < i2409.length; i += 2) {
  request.r(i2409[i + 0], i2409[i + 1], 2, i2408, '')
  }
  i2402.m_AtlasTextures = i2408
  i2402.m_AtlasTextureIndex = i2403[18]
  i2402.m_IsMultiAtlasTexturesEnabled = !!i2403[19]
  i2402.m_GetFontFeatures = !!i2403[20]
  i2402.m_ClearDynamicDataOnBuild = !!i2403[21]
  i2402.m_AtlasWidth = i2403[22]
  i2402.m_AtlasHeight = i2403[23]
  i2402.m_AtlasPadding = i2403[24]
  i2402.m_AtlasRenderMode = i2403[25]
  var i2411 = i2403[26]
  var i2410 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.TextCore.GlyphRect')))
  for(var i = 0; i < i2411.length; i += 1) {
    i2410.add(request.d('UnityEngine.TextCore.GlyphRect', i2411[i + 0]));
  }
  i2402.m_UsedGlyphRects = i2410
  var i2413 = i2403[27]
  var i2412 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.TextCore.GlyphRect')))
  for(var i = 0; i < i2413.length; i += 1) {
    i2412.add(request.d('UnityEngine.TextCore.GlyphRect', i2413[i + 0]));
  }
  i2402.m_FreeGlyphRects = i2412
  i2402.m_FontFeatureTable = request.d('TMPro.TMP_FontFeatureTable', i2403[28], i2402.m_FontFeatureTable)
  i2402.m_ShouldReimportFontFeatures = !!i2403[29]
  var i2415 = i2403[30]
  var i2414 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_FontAsset')))
  for(var i = 0; i < i2415.length; i += 2) {
  request.r(i2415[i + 0], i2415[i + 1], 1, i2414, '')
  }
  i2402.m_FallbackFontAssetTable = i2414
  var i2417 = i2403[31]
  var i2416 = []
  for(var i = 0; i < i2417.length; i += 1) {
    i2416.push( request.d('TMPro.TMP_FontWeightPair', i2417[i + 0]) );
  }
  i2402.m_FontWeightTable = i2416
  var i2419 = i2403[32]
  var i2418 = []
  for(var i = 0; i < i2419.length; i += 1) {
    i2418.push( request.d('TMPro.TMP_FontWeightPair', i2419[i + 0]) );
  }
  i2402.fontWeights = i2418
  i2402.m_fontInfo = request.d('TMPro.FaceInfo_Legacy', i2403[33], i2402.m_fontInfo)
  var i2421 = i2403[34]
  var i2420 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_Glyph')))
  for(var i = 0; i < i2421.length; i += 1) {
    i2420.add(request.d('TMPro.TMP_Glyph', i2421[i + 0]));
  }
  i2402.m_glyphInfoList = i2420
  i2402.m_KerningTable = request.d('TMPro.KerningTable', i2403[35], i2402.m_KerningTable)
  var i2423 = i2403[36]
  var i2422 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_FontAsset')))
  for(var i = 0; i < i2423.length; i += 2) {
  request.r(i2423[i + 0], i2423[i + 1], 1, i2422, '')
  }
  i2402.fallbackFontAssets = i2422
  i2402.m_Version = i2403[37]
  i2402.m_FaceInfo = request.d('UnityEngine.TextCore.FaceInfo', i2403[38], i2402.m_FaceInfo)
  request.r(i2403[39], i2403[40], 0, i2402, 'm_Material')
  return i2402
}

Deserializers["TMPro.FontAssetCreationSettings"] = function (request, data, root) {
  var i2424 = root || request.c( 'TMPro.FontAssetCreationSettings' )
  var i2425 = data
  i2424.sourceFontFileName = i2425[0]
  i2424.sourceFontFileGUID = i2425[1]
  i2424.faceIndex = i2425[2]
  i2424.pointSizeSamplingMode = i2425[3]
  i2424.pointSize = i2425[4]
  i2424.padding = i2425[5]
  i2424.paddingMode = i2425[6]
  i2424.packingMode = i2425[7]
  i2424.atlasWidth = i2425[8]
  i2424.atlasHeight = i2425[9]
  i2424.characterSetSelectionMode = i2425[10]
  i2424.characterSequence = i2425[11]
  i2424.referencedFontAssetGUID = i2425[12]
  i2424.referencedTextAssetGUID = i2425[13]
  i2424.fontStyle = i2425[14]
  i2424.fontStyleModifier = i2425[15]
  i2424.renderMode = i2425[16]
  i2424.includeFontFeatures = !!i2425[17]
  return i2424
}

Deserializers["UnityEngine.TextCore.Glyph"] = function (request, data, root) {
  var i2428 = root || request.c( 'UnityEngine.TextCore.Glyph' )
  var i2429 = data
  i2428.m_Index = i2429[0]
  i2428.m_Metrics = request.d('UnityEngine.TextCore.GlyphMetrics', i2429[1], i2428.m_Metrics)
  i2428.m_GlyphRect = request.d('UnityEngine.TextCore.GlyphRect', i2429[2], i2428.m_GlyphRect)
  i2428.m_Scale = i2429[3]
  i2428.m_AtlasIndex = i2429[4]
  i2428.m_ClassDefinitionType = i2429[5]
  return i2428
}

Deserializers["UnityEngine.TextCore.GlyphMetrics"] = function (request, data, root) {
  var i2430 = root || request.c( 'UnityEngine.TextCore.GlyphMetrics' )
  var i2431 = data
  i2430.m_Width = i2431[0]
  i2430.m_Height = i2431[1]
  i2430.m_HorizontalBearingX = i2431[2]
  i2430.m_HorizontalBearingY = i2431[3]
  i2430.m_HorizontalAdvance = i2431[4]
  return i2430
}

Deserializers["UnityEngine.TextCore.GlyphRect"] = function (request, data, root) {
  var i2432 = root || request.c( 'UnityEngine.TextCore.GlyphRect' )
  var i2433 = data
  i2432.m_X = i2433[0]
  i2432.m_Y = i2433[1]
  i2432.m_Width = i2433[2]
  i2432.m_Height = i2433[3]
  return i2432
}

Deserializers["TMPro.TMP_Character"] = function (request, data, root) {
  var i2436 = root || request.c( 'TMPro.TMP_Character' )
  var i2437 = data
  i2436.m_ElementType = i2437[0]
  i2436.m_Unicode = i2437[1]
  i2436.m_GlyphIndex = i2437[2]
  i2436.m_Scale = i2437[3]
  return i2436
}

Deserializers["TMPro.TMP_FontFeatureTable"] = function (request, data, root) {
  var i2442 = root || request.c( 'TMPro.TMP_FontFeatureTable' )
  var i2443 = data
  var i2445 = i2443[0]
  var i2444 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.MultipleSubstitutionRecord')))
  for(var i = 0; i < i2445.length; i += 1) {
    i2444.add(request.d('TMPro.MultipleSubstitutionRecord', i2445[i + 0]));
  }
  i2442.m_MultipleSubstitutionRecords = i2444
  var i2447 = i2443[1]
  var i2446 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.LigatureSubstitutionRecord')))
  for(var i = 0; i < i2447.length; i += 1) {
    i2446.add(request.d('TMPro.LigatureSubstitutionRecord', i2447[i + 0]));
  }
  i2442.m_LigatureSubstitutionRecords = i2446
  var i2449 = i2443[2]
  var i2448 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.TextCore.LowLevel.GlyphPairAdjustmentRecord')))
  for(var i = 0; i < i2449.length; i += 1) {
    i2448.add(request.d('UnityEngine.TextCore.LowLevel.GlyphPairAdjustmentRecord', i2449[i + 0]));
  }
  i2442.m_GlyphPairAdjustmentRecords = i2448
  var i2451 = i2443[3]
  var i2450 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.MarkToBaseAdjustmentRecord')))
  for(var i = 0; i < i2451.length; i += 1) {
    i2450.add(request.d('TMPro.MarkToBaseAdjustmentRecord', i2451[i + 0]));
  }
  i2442.m_MarkToBaseAdjustmentRecords = i2450
  var i2453 = i2443[4]
  var i2452 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.MarkToMarkAdjustmentRecord')))
  for(var i = 0; i < i2453.length; i += 1) {
    i2452.add(request.d('TMPro.MarkToMarkAdjustmentRecord', i2453[i + 0]));
  }
  i2442.m_MarkToMarkAdjustmentRecords = i2452
  return i2442
}

Deserializers["TMPro.MultipleSubstitutionRecord"] = function (request, data, root) {
  var i2456 = root || request.c( 'TMPro.MultipleSubstitutionRecord' )
  var i2457 = data
  i2456.m_TargetGlyphID = i2457[0]
  i2456.m_SubstituteGlyphIDs = i2457[1]
  return i2456
}

Deserializers["TMPro.LigatureSubstitutionRecord"] = function (request, data, root) {
  var i2460 = root || request.c( 'TMPro.LigatureSubstitutionRecord' )
  var i2461 = data
  i2460.m_ComponentGlyphIDs = i2461[0]
  i2460.m_LigatureGlyphID = i2461[1]
  return i2460
}

Deserializers["UnityEngine.TextCore.LowLevel.GlyphPairAdjustmentRecord"] = function (request, data, root) {
  var i2464 = root || request.c( 'UnityEngine.TextCore.LowLevel.GlyphPairAdjustmentRecord' )
  var i2465 = data
  i2464.m_FirstAdjustmentRecord = request.d('UnityEngine.TextCore.LowLevel.GlyphAdjustmentRecord', i2465[0], i2464.m_FirstAdjustmentRecord)
  i2464.m_SecondAdjustmentRecord = request.d('UnityEngine.TextCore.LowLevel.GlyphAdjustmentRecord', i2465[1], i2464.m_SecondAdjustmentRecord)
  i2464.m_FeatureLookupFlags = i2465[2]
  return i2464
}

Deserializers["UnityEngine.TextCore.LowLevel.GlyphAdjustmentRecord"] = function (request, data, root) {
  var i2466 = root || request.c( 'UnityEngine.TextCore.LowLevel.GlyphAdjustmentRecord' )
  var i2467 = data
  i2466.m_GlyphIndex = i2467[0]
  i2466.m_GlyphValueRecord = request.d('UnityEngine.TextCore.LowLevel.GlyphValueRecord', i2467[1], i2466.m_GlyphValueRecord)
  return i2466
}

Deserializers["UnityEngine.TextCore.LowLevel.GlyphValueRecord"] = function (request, data, root) {
  var i2468 = root || request.c( 'UnityEngine.TextCore.LowLevel.GlyphValueRecord' )
  var i2469 = data
  i2468.m_XPlacement = i2469[0]
  i2468.m_YPlacement = i2469[1]
  i2468.m_XAdvance = i2469[2]
  i2468.m_YAdvance = i2469[3]
  return i2468
}

Deserializers["TMPro.MarkToBaseAdjustmentRecord"] = function (request, data, root) {
  var i2472 = root || request.c( 'TMPro.MarkToBaseAdjustmentRecord' )
  var i2473 = data
  i2472.m_BaseGlyphID = i2473[0]
  i2472.m_BaseGlyphAnchorPoint = request.d('TMPro.GlyphAnchorPoint', i2473[1], i2472.m_BaseGlyphAnchorPoint)
  i2472.m_MarkGlyphID = i2473[2]
  i2472.m_MarkPositionAdjustment = request.d('TMPro.MarkPositionAdjustment', i2473[3], i2472.m_MarkPositionAdjustment)
  return i2472
}

Deserializers["TMPro.GlyphAnchorPoint"] = function (request, data, root) {
  var i2474 = root || request.c( 'TMPro.GlyphAnchorPoint' )
  var i2475 = data
  i2474.m_XCoordinate = i2475[0]
  i2474.m_YCoordinate = i2475[1]
  return i2474
}

Deserializers["TMPro.MarkPositionAdjustment"] = function (request, data, root) {
  var i2476 = root || request.c( 'TMPro.MarkPositionAdjustment' )
  var i2477 = data
  i2476.m_XPositionAdjustment = i2477[0]
  i2476.m_YPositionAdjustment = i2477[1]
  return i2476
}

Deserializers["TMPro.MarkToMarkAdjustmentRecord"] = function (request, data, root) {
  var i2480 = root || request.c( 'TMPro.MarkToMarkAdjustmentRecord' )
  var i2481 = data
  i2480.m_BaseMarkGlyphID = i2481[0]
  i2480.m_BaseMarkGlyphAnchorPoint = request.d('TMPro.GlyphAnchorPoint', i2481[1], i2480.m_BaseMarkGlyphAnchorPoint)
  i2480.m_CombiningMarkGlyphID = i2481[2]
  i2480.m_CombiningMarkPositionAdjustment = request.d('TMPro.MarkPositionAdjustment', i2481[3], i2480.m_CombiningMarkPositionAdjustment)
  return i2480
}

Deserializers["TMPro.TMP_FontWeightPair"] = function (request, data, root) {
  var i2486 = root || request.c( 'TMPro.TMP_FontWeightPair' )
  var i2487 = data
  request.r(i2487[0], i2487[1], 0, i2486, 'regularTypeface')
  request.r(i2487[2], i2487[3], 0, i2486, 'italicTypeface')
  return i2486
}

Deserializers["TMPro.FaceInfo_Legacy"] = function (request, data, root) {
  var i2488 = root || request.c( 'TMPro.FaceInfo_Legacy' )
  var i2489 = data
  i2488.Name = i2489[0]
  i2488.PointSize = i2489[1]
  i2488.Scale = i2489[2]
  i2488.CharacterCount = i2489[3]
  i2488.LineHeight = i2489[4]
  i2488.Baseline = i2489[5]
  i2488.Ascender = i2489[6]
  i2488.CapHeight = i2489[7]
  i2488.Descender = i2489[8]
  i2488.CenterLine = i2489[9]
  i2488.SuperscriptOffset = i2489[10]
  i2488.SubscriptOffset = i2489[11]
  i2488.SubSize = i2489[12]
  i2488.Underline = i2489[13]
  i2488.UnderlineThickness = i2489[14]
  i2488.strikethrough = i2489[15]
  i2488.strikethroughThickness = i2489[16]
  i2488.TabWidth = i2489[17]
  i2488.Padding = i2489[18]
  i2488.AtlasWidth = i2489[19]
  i2488.AtlasHeight = i2489[20]
  return i2488
}

Deserializers["TMPro.TMP_Glyph"] = function (request, data, root) {
  var i2492 = root || request.c( 'TMPro.TMP_Glyph' )
  var i2493 = data
  i2492.id = i2493[0]
  i2492.x = i2493[1]
  i2492.y = i2493[2]
  i2492.width = i2493[3]
  i2492.height = i2493[4]
  i2492.xOffset = i2493[5]
  i2492.yOffset = i2493[6]
  i2492.xAdvance = i2493[7]
  i2492.scale = i2493[8]
  return i2492
}

Deserializers["TMPro.KerningTable"] = function (request, data, root) {
  var i2494 = root || request.c( 'TMPro.KerningTable' )
  var i2495 = data
  var i2497 = i2495[0]
  var i2496 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.KerningPair')))
  for(var i = 0; i < i2497.length; i += 1) {
    i2496.add(request.d('TMPro.KerningPair', i2497[i + 0]));
  }
  i2494.kerningPairs = i2496
  return i2494
}

Deserializers["TMPro.KerningPair"] = function (request, data, root) {
  var i2500 = root || request.c( 'TMPro.KerningPair' )
  var i2501 = data
  i2500.xOffset = i2501[0]
  i2500.m_FirstGlyph = i2501[1]
  i2500.m_FirstGlyphAdjustments = request.d('TMPro.GlyphValueRecord_Legacy', i2501[2], i2500.m_FirstGlyphAdjustments)
  i2500.m_SecondGlyph = i2501[3]
  i2500.m_SecondGlyphAdjustments = request.d('TMPro.GlyphValueRecord_Legacy', i2501[4], i2500.m_SecondGlyphAdjustments)
  i2500.m_IgnoreSpacingAdjustments = !!i2501[5]
  return i2500
}

Deserializers["UnityEngine.TextCore.FaceInfo"] = function (request, data, root) {
  var i2502 = root || request.c( 'UnityEngine.TextCore.FaceInfo' )
  var i2503 = data
  i2502.m_FaceIndex = i2503[0]
  i2502.m_FamilyName = i2503[1]
  i2502.m_StyleName = i2503[2]
  i2502.m_PointSize = i2503[3]
  i2502.m_Scale = i2503[4]
  i2502.m_UnitsPerEM = i2503[5]
  i2502.m_LineHeight = i2503[6]
  i2502.m_AscentLine = i2503[7]
  i2502.m_CapLine = i2503[8]
  i2502.m_MeanLine = i2503[9]
  i2502.m_Baseline = i2503[10]
  i2502.m_DescentLine = i2503[11]
  i2502.m_SuperscriptOffset = i2503[12]
  i2502.m_SuperscriptSize = i2503[13]
  i2502.m_SubscriptOffset = i2503[14]
  i2502.m_SubscriptSize = i2503[15]
  i2502.m_UnderlineOffset = i2503[16]
  i2502.m_UnderlineThickness = i2503[17]
  i2502.m_StrikethroughOffset = i2503[18]
  i2502.m_StrikethroughThickness = i2503[19]
  i2502.m_TabWidth = i2503[20]
  return i2502
}

Deserializers["CustomGridShape"] = function (request, data, root) {
  var i2504 = root || request.c( 'CustomGridShape' )
  var i2505 = data
  var i2507 = i2505[0]
  var i2506 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.Vector2Int')))
  for(var i = 0; i < i2507.length; i += 2) {
    i2506.add(new pc.Vec2( i2507[i + 0], i2507[i + 1] ));
  }
  i2504.cells = i2506
  return i2504
}

Deserializers["ObjectSet"] = function (request, data, root) {
  var i2508 = root || request.c( 'ObjectSet' )
  var i2509 = data
  i2508.Name = i2509[0]
  request.r(i2509[1], i2509[2], 0, i2508, 'RewardCardSprite')
  var i2511 = i2509[3]
  var i2510 = new (System.Collections.Generic.List$1(Bridge.ns('ObjectMapping')))
  for(var i = 0; i < i2511.length; i += 1) {
    i2510.add(request.d('ObjectMapping', i2511[i + 0]));
  }
  i2508.Mappings = i2510
  return i2508
}

Deserializers["ObjectMapping"] = function (request, data, root) {
  var i2514 = root || request.c( 'ObjectMapping' )
  var i2515 = data
  i2514.GenericId = i2515[0]
  i2514.ConcreteType = i2515[1]
  return i2514
}

Deserializers["TMPro.TMP_SpriteAsset"] = function (request, data, root) {
  var i2516 = root || request.c( 'TMPro.TMP_SpriteAsset' )
  var i2517 = data
  request.r(i2517[0], i2517[1], 0, i2516, 'spriteSheet')
  var i2519 = i2517[2]
  var i2518 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_Sprite')))
  for(var i = 0; i < i2519.length; i += 1) {
    i2518.add(request.d('TMPro.TMP_Sprite', i2519[i + 0]));
  }
  i2516.spriteInfoList = i2518
  var i2521 = i2517[3]
  var i2520 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_SpriteAsset')))
  for(var i = 0; i < i2521.length; i += 2) {
  request.r(i2521[i + 0], i2521[i + 1], 1, i2520, '')
  }
  i2516.fallbackSpriteAssets = i2520
  var i2523 = i2517[4]
  var i2522 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_SpriteCharacter')))
  for(var i = 0; i < i2523.length; i += 1) {
    i2522.add(request.d('TMPro.TMP_SpriteCharacter', i2523[i + 0]));
  }
  i2516.m_SpriteCharacterTable = i2522
  var i2525 = i2517[5]
  var i2524 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_SpriteGlyph')))
  for(var i = 0; i < i2525.length; i += 1) {
    i2524.add(request.d('TMPro.TMP_SpriteGlyph', i2525[i + 0]));
  }
  i2516.m_GlyphTable = i2524
  i2516.m_Version = i2517[6]
  i2516.m_FaceInfo = request.d('UnityEngine.TextCore.FaceInfo', i2517[7], i2516.m_FaceInfo)
  request.r(i2517[8], i2517[9], 0, i2516, 'm_Material')
  return i2516
}

Deserializers["TMPro.TMP_Sprite"] = function (request, data, root) {
  var i2528 = root || request.c( 'TMPro.TMP_Sprite' )
  var i2529 = data
  i2528.name = i2529[0]
  i2528.hashCode = i2529[1]
  i2528.unicode = i2529[2]
  i2528.pivot = new pc.Vec2( i2529[3], i2529[4] )
  request.r(i2529[5], i2529[6], 0, i2528, 'sprite')
  i2528.id = i2529[7]
  i2528.x = i2529[8]
  i2528.y = i2529[9]
  i2528.width = i2529[10]
  i2528.height = i2529[11]
  i2528.xOffset = i2529[12]
  i2528.yOffset = i2529[13]
  i2528.xAdvance = i2529[14]
  i2528.scale = i2529[15]
  return i2528
}

Deserializers["TMPro.TMP_SpriteCharacter"] = function (request, data, root) {
  var i2534 = root || request.c( 'TMPro.TMP_SpriteCharacter' )
  var i2535 = data
  i2534.m_Name = i2535[0]
  i2534.m_ElementType = i2535[1]
  i2534.m_Unicode = i2535[2]
  i2534.m_GlyphIndex = i2535[3]
  i2534.m_Scale = i2535[4]
  return i2534
}

Deserializers["TMPro.TMP_SpriteGlyph"] = function (request, data, root) {
  var i2538 = root || request.c( 'TMPro.TMP_SpriteGlyph' )
  var i2539 = data
  request.r(i2539[0], i2539[1], 0, i2538, 'sprite')
  i2538.m_Index = i2539[2]
  i2538.m_Metrics = request.d('UnityEngine.TextCore.GlyphMetrics', i2539[3], i2538.m_Metrics)
  i2538.m_GlyphRect = request.d('UnityEngine.TextCore.GlyphRect', i2539[4], i2538.m_GlyphRect)
  i2538.m_Scale = i2539[5]
  i2538.m_AtlasIndex = i2539[6]
  i2538.m_ClassDefinitionType = i2539[7]
  return i2538
}

Deserializers["TMPro.TMP_StyleSheet"] = function (request, data, root) {
  var i2540 = root || request.c( 'TMPro.TMP_StyleSheet' )
  var i2541 = data
  var i2543 = i2541[0]
  var i2542 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_Style')))
  for(var i = 0; i < i2543.length; i += 1) {
    i2542.add(request.d('TMPro.TMP_Style', i2543[i + 0]));
  }
  i2540.m_StyleList = i2542
  return i2540
}

Deserializers["TMPro.TMP_Style"] = function (request, data, root) {
  var i2546 = root || request.c( 'TMPro.TMP_Style' )
  var i2547 = data
  i2546.m_Name = i2547[0]
  i2546.m_HashCode = i2547[1]
  i2546.m_OpeningDefinition = i2547[2]
  i2546.m_ClosingDefinition = i2547[3]
  i2546.m_OpeningTagArray = i2547[4]
  i2546.m_ClosingTagArray = i2547[5]
  return i2546
}

Deserializers["TMPro.TMP_Settings"] = function (request, data, root) {
  var i2548 = root || request.c( 'TMPro.TMP_Settings' )
  var i2549 = data
  i2548.assetVersion = i2549[0]
  i2548.m_TextWrappingMode = i2549[1]
  i2548.m_enableKerning = !!i2549[2]
  var i2551 = i2549[3]
  var i2550 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.TextCore.OTL_FeatureTag')))
  for(var i = 0; i < i2551.length; i += 1) {
    i2550.add(i2551[i + 0]);
  }
  i2548.m_ActiveFontFeatures = i2550
  i2548.m_enableExtraPadding = !!i2549[4]
  i2548.m_enableTintAllSprites = !!i2549[5]
  i2548.m_enableParseEscapeCharacters = !!i2549[6]
  i2548.m_EnableRaycastTarget = !!i2549[7]
  i2548.m_GetFontFeaturesAtRuntime = !!i2549[8]
  i2548.m_missingGlyphCharacter = i2549[9]
  i2548.m_ClearDynamicDataOnBuild = !!i2549[10]
  i2548.m_warningsDisabled = !!i2549[11]
  request.r(i2549[12], i2549[13], 0, i2548, 'm_defaultFontAsset')
  i2548.m_defaultFontAssetPath = i2549[14]
  i2548.m_defaultFontSize = i2549[15]
  i2548.m_defaultAutoSizeMinRatio = i2549[16]
  i2548.m_defaultAutoSizeMaxRatio = i2549[17]
  i2548.m_defaultTextMeshProTextContainerSize = new pc.Vec2( i2549[18], i2549[19] )
  i2548.m_defaultTextMeshProUITextContainerSize = new pc.Vec2( i2549[20], i2549[21] )
  i2548.m_autoSizeTextContainer = !!i2549[22]
  i2548.m_IsTextObjectScaleStatic = !!i2549[23]
  var i2553 = i2549[24]
  var i2552 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_FontAsset')))
  for(var i = 0; i < i2553.length; i += 2) {
  request.r(i2553[i + 0], i2553[i + 1], 1, i2552, '')
  }
  i2548.m_fallbackFontAssets = i2552
  i2548.m_matchMaterialPreset = !!i2549[25]
  i2548.m_HideSubTextObjects = !!i2549[26]
  request.r(i2549[27], i2549[28], 0, i2548, 'm_defaultSpriteAsset')
  i2548.m_defaultSpriteAssetPath = i2549[29]
  i2548.m_enableEmojiSupport = !!i2549[30]
  i2548.m_MissingCharacterSpriteUnicode = i2549[31]
  var i2555 = i2549[32]
  var i2554 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_Asset')))
  for(var i = 0; i < i2555.length; i += 2) {
  request.r(i2555[i + 0], i2555[i + 1], 1, i2554, '')
  }
  i2548.m_EmojiFallbackTextAssets = i2554
  i2548.m_defaultColorGradientPresetsPath = i2549[33]
  request.r(i2549[34], i2549[35], 0, i2548, 'm_defaultStyleSheet')
  i2548.m_StyleSheetsResourcePath = i2549[36]
  request.r(i2549[37], i2549[38], 0, i2548, 'm_leadingCharacters')
  request.r(i2549[39], i2549[40], 0, i2548, 'm_followingCharacters')
  i2548.m_UseModernHangulLineBreakingRules = !!i2549[41]
  return i2548
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Resources"] = function (request, data, root) {
  var i2558 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Resources' )
  var i2559 = data
  var i2561 = i2559[0]
  var i2560 = []
  for(var i = 0; i < i2561.length; i += 1) {
    i2560.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Resources+File', i2561[i + 0]) );
  }
  i2558.files = i2560
  i2558.componentToPrefabIds = i2559[1]
  return i2558
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Resources+File"] = function (request, data, root) {
  var i2564 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Resources+File' )
  var i2565 = data
  i2564.path = i2565[0]
  request.r(i2565[1], i2565[2], 0, i2564, 'unityObject')
  return i2564
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings"] = function (request, data, root) {
  var i2566 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings' )
  var i2567 = data
  var i2569 = i2567[0]
  var i2568 = []
  for(var i = 0; i < i2569.length; i += 1) {
    i2568.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+ScriptsExecutionOrder', i2569[i + 0]) );
  }
  i2566.scriptsExecutionOrder = i2568
  var i2571 = i2567[1]
  var i2570 = []
  for(var i = 0; i < i2571.length; i += 1) {
    i2570.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+SortingLayer', i2571[i + 0]) );
  }
  i2566.sortingLayers = i2570
  var i2573 = i2567[2]
  var i2572 = []
  for(var i = 0; i < i2573.length; i += 1) {
    i2572.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+CullingLayer', i2573[i + 0]) );
  }
  i2566.cullingLayers = i2572
  i2566.timeSettings = request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+TimeSettings', i2567[3], i2566.timeSettings)
  i2566.physicsSettings = request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings', i2567[4], i2566.physicsSettings)
  i2566.physics2DSettings = request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings', i2567[5], i2566.physics2DSettings)
  i2566.qualitySettings = request.d('Luna.Unity.DTO.UnityEngine.Assets.QualitySettings', i2567[6], i2566.qualitySettings)
  i2566.enableRealtimeShadows = !!i2567[7]
  i2566.enableAutoInstancing = !!i2567[8]
  i2566.enableStaticBatching = !!i2567[9]
  i2566.enableDynamicBatching = !!i2567[10]
  i2566.usePreservativeDynamicBatching = !!i2567[11]
  i2566.lightmapEncodingQuality = i2567[12]
  i2566.desiredColorSpace = i2567[13]
  var i2575 = i2567[14]
  var i2574 = []
  for(var i = 0; i < i2575.length; i += 1) {
    i2574.push( i2575[i + 0] );
  }
  i2566.allTags = i2574
  return i2566
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+ScriptsExecutionOrder"] = function (request, data, root) {
  var i2578 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+ScriptsExecutionOrder' )
  var i2579 = data
  i2578.name = i2579[0]
  i2578.value = i2579[1]
  return i2578
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+SortingLayer"] = function (request, data, root) {
  var i2582 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+SortingLayer' )
  var i2583 = data
  i2582.id = i2583[0]
  i2582.name = i2583[1]
  i2582.value = i2583[2]
  return i2582
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+CullingLayer"] = function (request, data, root) {
  var i2586 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+CullingLayer' )
  var i2587 = data
  i2586.id = i2587[0]
  i2586.name = i2587[1]
  return i2586
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+TimeSettings"] = function (request, data, root) {
  var i2588 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+TimeSettings' )
  var i2589 = data
  i2588.fixedDeltaTime = i2589[0]
  i2588.maximumDeltaTime = i2589[1]
  i2588.timeScale = i2589[2]
  i2588.maximumParticleTimestep = i2589[3]
  return i2588
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings"] = function (request, data, root) {
  var i2590 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings' )
  var i2591 = data
  i2590.gravity = new pc.Vec3( i2591[0], i2591[1], i2591[2] )
  i2590.defaultSolverIterations = i2591[3]
  i2590.bounceThreshold = i2591[4]
  i2590.autoSyncTransforms = !!i2591[5]
  i2590.autoSimulation = !!i2591[6]
  var i2593 = i2591[7]
  var i2592 = []
  for(var i = 0; i < i2593.length; i += 1) {
    i2592.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings+CollisionMask', i2593[i + 0]) );
  }
  i2590.collisionMatrix = i2592
  return i2590
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings+CollisionMask"] = function (request, data, root) {
  var i2596 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings+CollisionMask' )
  var i2597 = data
  i2596.enabled = !!i2597[0]
  i2596.layerId = i2597[1]
  i2596.otherLayerId = i2597[2]
  return i2596
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings"] = function (request, data, root) {
  var i2598 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings' )
  var i2599 = data
  request.r(i2599[0], i2599[1], 0, i2598, 'material')
  i2598.gravity = new pc.Vec2( i2599[2], i2599[3] )
  i2598.positionIterations = i2599[4]
  i2598.velocityIterations = i2599[5]
  i2598.velocityThreshold = i2599[6]
  i2598.maxLinearCorrection = i2599[7]
  i2598.maxAngularCorrection = i2599[8]
  i2598.maxTranslationSpeed = i2599[9]
  i2598.maxRotationSpeed = i2599[10]
  i2598.baumgarteScale = i2599[11]
  i2598.baumgarteTOIScale = i2599[12]
  i2598.timeToSleep = i2599[13]
  i2598.linearSleepTolerance = i2599[14]
  i2598.angularSleepTolerance = i2599[15]
  i2598.defaultContactOffset = i2599[16]
  i2598.autoSimulation = !!i2599[17]
  i2598.queriesHitTriggers = !!i2599[18]
  i2598.queriesStartInColliders = !!i2599[19]
  i2598.callbacksOnDisable = !!i2599[20]
  i2598.reuseCollisionCallbacks = !!i2599[21]
  i2598.autoSyncTransforms = !!i2599[22]
  var i2601 = i2599[23]
  var i2600 = []
  for(var i = 0; i < i2601.length; i += 1) {
    i2600.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings+CollisionMask', i2601[i + 0]) );
  }
  i2598.collisionMatrix = i2600
  return i2598
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings+CollisionMask"] = function (request, data, root) {
  var i2604 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings+CollisionMask' )
  var i2605 = data
  i2604.enabled = !!i2605[0]
  i2604.layerId = i2605[1]
  i2604.otherLayerId = i2605[2]
  return i2604
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.QualitySettings"] = function (request, data, root) {
  var i2606 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.QualitySettings' )
  var i2607 = data
  var i2609 = i2607[0]
  var i2608 = []
  for(var i = 0; i < i2609.length; i += 1) {
    i2608.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.QualitySettings', i2609[i + 0]) );
  }
  i2606.qualityLevels = i2608
  var i2611 = i2607[1]
  var i2610 = []
  for(var i = 0; i < i2611.length; i += 1) {
    i2610.push( i2611[i + 0] );
  }
  i2606.names = i2610
  i2606.shadows = i2607[2]
  i2606.anisotropicFiltering = i2607[3]
  i2606.antiAliasing = i2607[4]
  i2606.lodBias = i2607[5]
  i2606.shadowCascades = i2607[6]
  i2606.shadowDistance = i2607[7]
  i2606.shadowmaskMode = i2607[8]
  i2606.shadowProjection = i2607[9]
  i2606.shadowResolution = i2607[10]
  i2606.softParticles = !!i2607[11]
  i2606.softVegetation = !!i2607[12]
  i2606.activeColorSpace = i2607[13]
  i2606.desiredColorSpace = i2607[14]
  i2606.masterTextureLimit = i2607[15]
  i2606.maxQueuedFrames = i2607[16]
  i2606.particleRaycastBudget = i2607[17]
  i2606.pixelLightCount = i2607[18]
  i2606.realtimeReflectionProbes = !!i2607[19]
  i2606.shadowCascade2Split = i2607[20]
  i2606.shadowCascade4Split = new pc.Vec3( i2607[21], i2607[22], i2607[23] )
  i2606.streamingMipmapsActive = !!i2607[24]
  i2606.vSyncCount = i2607[25]
  i2606.asyncUploadBufferSize = i2607[26]
  i2606.asyncUploadTimeSlice = i2607[27]
  i2606.billboardsFaceCameraPosition = !!i2607[28]
  i2606.shadowNearPlaneOffset = i2607[29]
  i2606.streamingMipmapsMemoryBudget = i2607[30]
  i2606.maximumLODLevel = i2607[31]
  i2606.streamingMipmapsAddAllCameras = !!i2607[32]
  i2606.streamingMipmapsMaxLevelReduction = i2607[33]
  i2606.streamingMipmapsRenderersPerFrame = i2607[34]
  i2606.resolutionScalingFixedDPIFactor = i2607[35]
  i2606.streamingMipmapsMaxFileIORequests = i2607[36]
  i2606.currentQualityLevel = i2607[37]
  return i2606
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.RenderObjects+RenderObjectsSettings"] = function (request, data, root) {
  var i2614 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.RenderObjects+RenderObjectsSettings' )
  var i2615 = data
  i2614.Event = request.d('Luna.Unity.DTO.UnityEngine.Assets.EnumDescription', i2615[0], i2614.Event)
  i2614.filterSettings = request.d('Luna.Unity.DTO.UnityEngine.Assets.RenderObjects+FilterSettings', i2615[1], i2614.filterSettings)
  i2614.overrideMaterialId = i2615[2]
  i2614.overrideMaterialPassIndex = i2615[3]
  i2614.overrideShaderId = i2615[4]
  i2614.overrideShaderPassIndex = i2615[5]
  i2614.overrideMode = request.d('Luna.Unity.DTO.UnityEngine.Assets.EnumDescription', i2615[6], i2614.overrideMode)
  i2614.overrideDepthState = !!i2615[7]
  i2614.depthCompareFunction = request.d('Luna.Unity.DTO.UnityEngine.Assets.EnumDescription', i2615[8], i2614.depthCompareFunction)
  i2614.enableWrite = !!i2615[9]
  i2614.stencilSettings = request.d('Luna.Unity.DTO.UnityEngine.Assets.StencilStateData', i2615[10], i2614.stencilSettings)
  i2614.cameraSettings = request.d('Luna.Unity.DTO.UnityEngine.Assets.RenderObjects+CustomCameraSettings', i2615[11], i2614.cameraSettings)
  return i2614
}

Deserializers["TMPro.GlyphValueRecord_Legacy"] = function (request, data, root) {
  var i2616 = root || request.c( 'TMPro.GlyphValueRecord_Legacy' )
  var i2617 = data
  i2616.xPlacement = i2617[0]
  i2616.yPlacement = i2617[1]
  i2616.xAdvance = i2617[2]
  i2616.yAdvance = i2617[3]
  return i2616
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.EnumDescription"] = function (request, data, root) {
  var i2618 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.EnumDescription' )
  var i2619 = data
  i2618.Value = i2619[0]
  return i2618
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.RenderObjects+FilterSettings"] = function (request, data, root) {
  var i2620 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.RenderObjects+FilterSettings' )
  var i2621 = data
  i2620.RenderQueueType = request.d('Luna.Unity.DTO.UnityEngine.Assets.EnumDescription', i2621[0], i2620.RenderQueueType)
  i2620.LayerMask = i2621[1]
  var i2623 = i2621[2]
  var i2622 = []
  for(var i = 0; i < i2623.length; i += 1) {
    i2622.push( i2623[i + 0] );
  }
  i2620.PassNames = i2622
  return i2620
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.StencilStateData"] = function (request, data, root) {
  var i2624 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.StencilStateData' )
  var i2625 = data
  i2624.overrideStencilState = !!i2625[0]
  i2624.stencilReference = i2625[1]
  i2624.stencilCompareFunctionValue = request.d('Luna.Unity.DTO.UnityEngine.Assets.EnumDescription', i2625[2], i2624.stencilCompareFunctionValue)
  i2624.passOperationValue = request.d('Luna.Unity.DTO.UnityEngine.Assets.EnumDescription', i2625[3], i2624.passOperationValue)
  i2624.failOperationValue = request.d('Luna.Unity.DTO.UnityEngine.Assets.EnumDescription', i2625[4], i2624.failOperationValue)
  i2624.zFailOperationValue = request.d('Luna.Unity.DTO.UnityEngine.Assets.EnumDescription', i2625[5], i2624.zFailOperationValue)
  return i2624
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.RenderObjects+CustomCameraSettings"] = function (request, data, root) {
  var i2626 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.RenderObjects+CustomCameraSettings' )
  var i2627 = data
  i2626.overrideCamera = !!i2627[0]
  i2626.restoreCamera = !!i2627[1]
  i2626.offset = new pc.Vec4( i2627[2], i2627[3], i2627[4], i2627[5] )
  i2626.cameraFieldOfView = i2627[6]
  return i2626
}

Deserializers.fields = {"Luna.Unity.DTO.UnityEngine.Assets.Material":{"name":0,"shader":1,"renderQueue":3,"enableInstancing":4,"floatParameters":5,"colorParameters":6,"vectorParameters":7,"textureParameters":8,"materialFlags":9},"Luna.Unity.DTO.UnityEngine.Assets.Material+FloatParameter":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.Material+ColorParameter":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.Material+VectorParameter":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.Material+TextureParameter":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.Material+MaterialFlag":{"name":0,"enabled":1},"Luna.Unity.DTO.UnityEngine.Textures.Texture2D":{"name":0,"width":1,"height":2,"mipmapCount":3,"anisoLevel":4,"filterMode":5,"hdr":6,"format":7,"wrapMode":8,"alphaIsTransparency":9,"alphaSource":10,"graphicsFormat":11,"sRGBTexture":12,"desiredColorSpace":13,"wrapU":14,"wrapV":15},"Luna.Unity.DTO.UnityEngine.Components.Transform":{"position":0,"scale":3,"rotation":6},"Luna.Unity.DTO.UnityEngine.Components.SpriteRenderer":{"color":0,"sprite":4,"flipX":6,"flipY":7,"drawMode":8,"size":9,"tileMode":11,"adaptiveModeThreshold":12,"maskInteraction":13,"spriteSortPoint":14,"enabled":15,"sharedMaterial":16,"sharedMaterials":18,"receiveShadows":19,"shadowCastingMode":20,"sortingLayerID":21,"sortingOrder":22,"lightmapIndex":23,"lightmapSceneIndex":24,"lightmapScaleOffset":25,"lightProbeUsage":29,"reflectionProbeUsage":30},"Luna.Unity.DTO.UnityEngine.Components.SortingGroup":{"sortingLayerIndex":0,"sortingOrder":1,"sortingLayerName":2,"enabled":3},"Luna.Unity.DTO.UnityEngine.Scene.GameObject":{"name":0,"tagId":1,"enabled":2,"isStatic":3,"layer":4},"Luna.Unity.DTO.UnityEngine.Components.ParticleSystemRenderer":{"mesh":0,"meshCount":2,"activeVertexStreamsCount":3,"alignment":4,"renderMode":5,"sortMode":6,"lengthScale":7,"velocityScale":8,"cameraVelocityScale":9,"normalDirection":10,"sortingFudge":11,"minParticleSize":12,"maxParticleSize":13,"pivot":14,"trailMaterial":17,"applyActiveColorSpace":19,"enabled":20,"sharedMaterial":21,"sharedMaterials":23,"receiveShadows":24,"shadowCastingMode":25,"sortingLayerID":26,"sortingOrder":27,"lightmapIndex":28,"lightmapSceneIndex":29,"lightmapScaleOffset":30,"lightProbeUsage":34,"reflectionProbeUsage":35},"Luna.Unity.DTO.UnityEngine.Components.ParticleSystem":{"main":0,"colorBySpeed":1,"colorOverLifetime":2,"emission":3,"rotationBySpeed":4,"rotationOverLifetime":5,"shape":6,"sizeBySpeed":7,"sizeOverLifetime":8,"textureSheetAnimation":9,"velocityOverLifetime":10,"noise":11,"inheritVelocity":12,"forceOverLifetime":13,"limitVelocityOverLifetime":14,"useAutoRandomSeed":15,"randomSeed":16},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.MainModule":{"duration":0,"loop":1,"prewarm":2,"startDelay":3,"startLifetime":4,"startSpeed":5,"startSize3D":6,"startSizeX":7,"startSizeY":8,"startSizeZ":9,"startRotation3D":10,"startRotationX":11,"startRotationY":12,"startRotationZ":13,"startColor":14,"gravityModifier":15,"simulationSpace":16,"customSimulationSpace":17,"simulationSpeed":19,"useUnscaledTime":20,"scalingMode":21,"playOnAwake":22,"maxParticles":23,"emitterVelocityMode":24,"stopAction":25},"Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve":{"mode":0,"curveMin":1,"curveMax":2,"curveMultiplier":3,"constantMin":4,"constantMax":5},"Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxGradient":{"mode":0,"gradientMin":1,"gradientMax":2,"colorMin":3,"colorMax":7},"Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Gradient":{"mode":0,"colorKeys":1,"alphaKeys":2},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ColorBySpeedModule":{"enabled":0,"color":1,"range":2},"Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Data.GradientColorKey":{"color":0,"time":4},"Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Data.GradientAlphaKey":{"alpha":0,"time":1},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ColorOverLifetimeModule":{"enabled":0,"color":1},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.EmissionModule":{"enabled":0,"rateOverTime":1,"rateOverDistance":2,"bursts":3},"Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Burst":{"count":0,"cycleCount":1,"minCount":2,"maxCount":3,"repeatInterval":4,"time":5},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.RotationBySpeedModule":{"enabled":0,"x":1,"y":2,"z":3,"separateAxes":4,"range":5},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.RotationOverLifetimeModule":{"enabled":0,"x":1,"y":2,"z":3,"separateAxes":4},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ShapeModule":{"enabled":0,"shapeType":1,"randomDirectionAmount":2,"sphericalDirectionAmount":3,"randomPositionAmount":4,"alignToDirection":5,"radius":6,"radiusMode":7,"radiusSpread":8,"radiusSpeed":9,"radiusThickness":10,"angle":11,"length":12,"boxThickness":13,"meshShapeType":16,"mesh":17,"meshRenderer":19,"skinnedMeshRenderer":21,"useMeshMaterialIndex":23,"meshMaterialIndex":24,"useMeshColors":25,"normalOffset":26,"arc":27,"arcMode":28,"arcSpread":29,"arcSpeed":30,"donutRadius":31,"position":32,"rotation":35,"scale":38},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.SizeBySpeedModule":{"enabled":0,"x":1,"y":2,"z":3,"separateAxes":4,"range":5},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.SizeOverLifetimeModule":{"enabled":0,"x":1,"y":2,"z":3,"separateAxes":4},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.TextureSheetAnimationModule":{"enabled":0,"mode":1,"animation":2,"numTilesX":3,"numTilesY":4,"useRandomRow":5,"frameOverTime":6,"startFrame":7,"cycleCount":8,"rowIndex":9,"flipU":10,"flipV":11,"spriteCount":12,"sprites":13},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.VelocityOverLifetimeModule":{"enabled":0,"x":1,"y":2,"z":3,"radial":4,"speedModifier":5,"space":6,"orbitalX":7,"orbitalY":8,"orbitalZ":9,"orbitalOffsetX":10,"orbitalOffsetY":11,"orbitalOffsetZ":12},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.NoiseModule":{"enabled":0,"separateAxes":1,"strengthX":2,"strengthY":3,"strengthZ":4,"frequency":5,"damping":6,"octaveCount":7,"octaveMultiplier":8,"octaveScale":9,"quality":10,"scrollSpeed":11,"scrollSpeedMultiplier":12,"remapEnabled":13,"remapX":14,"remapY":15,"remapZ":16,"positionAmount":17,"rotationAmount":18,"sizeAmount":19},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.InheritVelocityModule":{"enabled":0,"mode":1,"curve":2},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ForceOverLifetimeModule":{"enabled":0,"x":1,"y":2,"z":3,"space":4,"randomized":5},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.LimitVelocityOverLifetimeModule":{"enabled":0,"limit":1,"limitX":2,"limitY":3,"limitZ":4,"dampen":5,"separateAxes":6,"space":7,"drag":8,"multiplyDragByParticleSize":9,"multiplyDragByParticleVelocity":10},"Luna.Unity.DTO.UnityEngine.Components.BoxCollider2D":{"usedByComposite":0,"autoTiling":1,"size":2,"edgeRadius":4,"enabled":5,"isTrigger":6,"usedByEffector":7,"density":8,"offset":9,"material":11},"Luna.Unity.DTO.UnityEngine.Textures.Cubemap":{"name":0,"atlasId":1,"mipmapCount":2,"hdr":3,"size":4,"anisoLevel":5,"filterMode":6,"rects":7,"wrapU":8,"wrapV":9},"Luna.Unity.DTO.UnityEngine.Scene.Scene":{"name":0,"index":1,"startup":2},"Luna.Unity.DTO.UnityEngine.Components.Camera":{"aspect":0,"orthographic":1,"orthographicSize":2,"backgroundColor":3,"nearClipPlane":7,"farClipPlane":8,"fieldOfView":9,"depth":10,"clearFlags":11,"cullingMask":12,"rect":13,"targetTexture":14,"usePhysicalProperties":16,"focalLength":17,"sensorSize":18,"lensShift":20,"gateFit":22,"commandBufferCount":23,"cameraType":24,"enabled":25},"Luna.Unity.DTO.UnityEngine.Components.BoxCollider":{"center":0,"size":3,"enabled":6,"isTrigger":7,"material":8},"Luna.Unity.DTO.UnityEngine.Components.RectTransform":{"pivot":0,"anchorMin":2,"anchorMax":4,"sizeDelta":6,"anchoredPosition3D":8,"rotation":11,"scale":15},"Luna.Unity.DTO.UnityEngine.Components.Canvas":{"planeDistance":0,"referencePixelsPerUnit":1,"isFallbackOverlay":2,"renderMode":3,"renderOrder":4,"sortingLayerName":5,"sortingOrder":6,"scaleFactor":7,"worldCamera":8,"overrideSorting":10,"pixelPerfect":11,"targetDisplay":12,"overridePixelPerfect":13,"enabled":14},"Luna.Unity.DTO.UnityEngine.Components.CanvasRenderer":{"cullTransparentMesh":0},"Luna.Unity.DTO.UnityEngine.Components.AudioSource":{"clip":0,"outputAudioMixerGroup":2,"playOnAwake":4,"loop":5,"time":6,"volume":7,"pitch":8,"enabled":9},"Luna.Unity.DTO.UnityEngine.Assets.RenderSettings":{"ambientIntensity":0,"reflectionIntensity":1,"ambientMode":2,"ambientLight":3,"ambientSkyColor":7,"ambientGroundColor":11,"ambientEquatorColor":15,"fogColor":19,"fogEndDistance":23,"fogStartDistance":24,"fogDensity":25,"fog":26,"skybox":27,"fogMode":29,"lightmaps":30,"lightProbes":31,"lightmapsMode":32,"mixedBakeMode":33,"environmentLightingMode":34,"ambientProbe":35,"customReflection":36,"defaultReflection":38,"defaultReflectionMode":40,"defaultReflectionResolution":41,"sunLightObjectId":42,"pixelLightCount":43,"defaultReflectionHDR":44,"hasLightDataAsset":45,"hasManualGenerate":46},"Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+Lightmap":{"lightmapColor":0,"lightmapDirection":2,"shadowMask":4},"Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+LightProbes":{"bakedProbes":0,"positions":1,"hullRays":2,"tetrahedra":3,"neighbours":4,"matrices":5},"Luna.Unity.DTO.UnityEngine.Assets.UniversalRenderPipelineAsset":{"AdditionalLightsRenderingMode":0,"LightRenderingMode":1,"MainLightRenderingModeValue":2,"SupportsMainLightShadows":3,"MixedLightingSupported":4,"MainLightShadowmapResolutionValue":5,"SupportsSoftShadows":6,"SoftShadowQualityValue":7,"ShadowDistance":8,"ShadowCascadeCount":9,"Cascade2Split":10,"Cascade3Split":11,"Cascade4Split":13,"CascadeBorder":16,"ShadowDepthBias":17,"ShadowNormalBias":18,"RequireDepthTexture":19,"RequireOpaqueTexture":20,"scriptableRendererData":21},"Luna.Unity.DTO.UnityEngine.Assets.LightRenderingMode":{"Disabled":0,"PerVertex":1,"PerPixel":2},"Luna.Unity.DTO.UnityEngine.Assets.ScriptableRendererData":{"opaqueLayerMask":0,"transparentLayerMask":1,"RenderObjectsFeatures":2,"name":3},"Luna.Unity.DTO.UnityEngine.Assets.RenderObjects":{"settings":0,"name":1,"typeName":2},"Luna.Unity.DTO.UnityEngine.Assets.Shader":{"ShaderCompilationErrors":0,"name":1,"guid":2,"shaderDefinedKeywords":3,"passes":4,"usePasses":5,"defaultParameterValues":6,"unityFallbackShader":7,"readDepth":9,"hasDepthOnlyPass":10,"isCreatedByShaderGraph":11,"disableBatching":12,"compiled":13},"Luna.Unity.DTO.UnityEngine.Assets.Shader+ShaderCompilationError":{"shaderName":0,"errorMessage":1},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass":{"id":0,"subShaderIndex":1,"name":2,"passType":3,"grabPassTextureName":4,"usePass":5,"zTest":6,"zWrite":7,"culling":8,"blending":9,"alphaBlending":10,"colorWriteMask":11,"offsetUnits":12,"offsetFactor":13,"stencilRef":14,"stencilReadMask":15,"stencilWriteMask":16,"stencilOp":17,"stencilOpFront":18,"stencilOpBack":19,"tags":20,"passDefinedKeywords":21,"passDefinedKeywordGroups":22,"variants":23,"excludedVariants":24,"hasDepthReader":25},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value":{"val":0,"name":1},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Blending":{"src":0,"dst":1,"op":2},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp":{"pass":0,"fail":1,"zFail":2,"comp":3},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Tag":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+KeywordGroup":{"keywords":0,"hasDiscard":1},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Variant":{"passId":0,"subShaderIndex":1,"keywords":2,"vertexProgram":3,"fragmentProgram":4,"exportedForWebGl2":5,"readDepth":6},"Luna.Unity.DTO.UnityEngine.Assets.Shader+UsePass":{"shader":0,"pass":2},"Luna.Unity.DTO.UnityEngine.Assets.Shader+DefaultParameterValue":{"name":0,"type":1,"value":2,"textureValue":6,"shaderPropertyFlag":7},"Luna.Unity.DTO.UnityEngine.Textures.Sprite":{"name":0,"texture":1,"aabb":3,"vertices":4,"triangles":5,"textureRect":6,"packedRect":10,"border":14,"transparency":18,"bounds":19,"pixelsPerUnit":20,"textureWidth":21,"textureHeight":22,"nativeSize":23,"pivot":25,"textureRectOffset":27},"Luna.Unity.DTO.UnityEngine.Assets.AudioClip":{"name":0},"Luna.Unity.DTO.UnityEngine.Assets.Font":{"name":0,"ascent":1,"originalLineHeight":2,"fontSize":3,"characterInfo":4,"texture":5,"originalFontSize":7},"Luna.Unity.DTO.UnityEngine.Assets.Font+CharacterInfo":{"index":0,"advance":1,"bearing":2,"glyphWidth":3,"glyphHeight":4,"minX":5,"maxX":6,"minY":7,"maxY":8,"uvBottomLeftX":9,"uvBottomLeftY":10,"uvBottomRightX":11,"uvBottomRightY":12,"uvTopLeftX":13,"uvTopLeftY":14,"uvTopRightX":15,"uvTopRightY":16},"Luna.Unity.DTO.UnityEngine.Assets.Resources":{"files":0,"componentToPrefabIds":1},"Luna.Unity.DTO.UnityEngine.Assets.Resources+File":{"path":0,"unityObject":1},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings":{"scriptsExecutionOrder":0,"sortingLayers":1,"cullingLayers":2,"timeSettings":3,"physicsSettings":4,"physics2DSettings":5,"qualitySettings":6,"enableRealtimeShadows":7,"enableAutoInstancing":8,"enableStaticBatching":9,"enableDynamicBatching":10,"usePreservativeDynamicBatching":11,"lightmapEncodingQuality":12,"desiredColorSpace":13,"allTags":14},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+ScriptsExecutionOrder":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+SortingLayer":{"id":0,"name":1,"value":2},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+CullingLayer":{"id":0,"name":1},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+TimeSettings":{"fixedDeltaTime":0,"maximumDeltaTime":1,"timeScale":2,"maximumParticleTimestep":3},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings":{"gravity":0,"defaultSolverIterations":3,"bounceThreshold":4,"autoSyncTransforms":5,"autoSimulation":6,"collisionMatrix":7},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings+CollisionMask":{"enabled":0,"layerId":1,"otherLayerId":2},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings":{"material":0,"gravity":2,"positionIterations":4,"velocityIterations":5,"velocityThreshold":6,"maxLinearCorrection":7,"maxAngularCorrection":8,"maxTranslationSpeed":9,"maxRotationSpeed":10,"baumgarteScale":11,"baumgarteTOIScale":12,"timeToSleep":13,"linearSleepTolerance":14,"angularSleepTolerance":15,"defaultContactOffset":16,"autoSimulation":17,"queriesHitTriggers":18,"queriesStartInColliders":19,"callbacksOnDisable":20,"reuseCollisionCallbacks":21,"autoSyncTransforms":22,"collisionMatrix":23},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings+CollisionMask":{"enabled":0,"layerId":1,"otherLayerId":2},"Luna.Unity.DTO.UnityEngine.Assets.QualitySettings":{"qualityLevels":0,"names":1,"shadows":2,"anisotropicFiltering":3,"antiAliasing":4,"lodBias":5,"shadowCascades":6,"shadowDistance":7,"shadowmaskMode":8,"shadowProjection":9,"shadowResolution":10,"softParticles":11,"softVegetation":12,"activeColorSpace":13,"desiredColorSpace":14,"masterTextureLimit":15,"maxQueuedFrames":16,"particleRaycastBudget":17,"pixelLightCount":18,"realtimeReflectionProbes":19,"shadowCascade2Split":20,"shadowCascade4Split":21,"streamingMipmapsActive":24,"vSyncCount":25,"asyncUploadBufferSize":26,"asyncUploadTimeSlice":27,"billboardsFaceCameraPosition":28,"shadowNearPlaneOffset":29,"streamingMipmapsMemoryBudget":30,"maximumLODLevel":31,"streamingMipmapsAddAllCameras":32,"streamingMipmapsMaxLevelReduction":33,"streamingMipmapsRenderersPerFrame":34,"resolutionScalingFixedDPIFactor":35,"streamingMipmapsMaxFileIORequests":36,"currentQualityLevel":37},"Luna.Unity.DTO.UnityEngine.Assets.RenderObjects+RenderObjectsSettings":{"Event":0,"filterSettings":1,"overrideMaterialId":2,"overrideMaterialPassIndex":3,"overrideShaderId":4,"overrideShaderPassIndex":5,"overrideMode":6,"overrideDepthState":7,"depthCompareFunction":8,"enableWrite":9,"stencilSettings":10,"cameraSettings":11},"Luna.Unity.DTO.UnityEngine.Assets.EnumDescription":{"Value":0},"Luna.Unity.DTO.UnityEngine.Assets.RenderObjects+FilterSettings":{"RenderQueueType":0,"LayerMask":1,"PassNames":2},"Luna.Unity.DTO.UnityEngine.Assets.StencilStateData":{"overrideStencilState":0,"stencilReference":1,"stencilCompareFunctionValue":2,"passOperationValue":3,"failOperationValue":4,"zFailOperationValue":5},"Luna.Unity.DTO.UnityEngine.Assets.RenderObjects+CustomCameraSettings":{"overrideCamera":0,"restoreCamera":1,"offset":2,"cameraFieldOfView":6},"Luna.Unity.DTO.UnityEngine.Assets.TextAsset":{"name":0,"bytes64":1,"data":2}}

Deserializers.requiredComponents = {"104":[105],"106":[105],"107":[105],"108":[105],"109":[105],"110":[105],"111":[112],"113":[19],"114":[115],"116":[115],"117":[115],"118":[115],"119":[115],"120":[115],"121":[122],"123":[122],"124":[122],"125":[122],"126":[122],"127":[122],"128":[122],"129":[122],"130":[122],"131":[122],"132":[122],"133":[122],"134":[122],"135":[19],"136":[137],"138":[139],"140":[139],"27":[26],"11":[141],"142":[24],"143":[27],"77":[26],"144":[19],"145":[19],"146":[147],"148":[26],"149":[30,26],"150":[137],"151":[30,26],"152":[26],"153":[26],"154":[137,26],"32":[26,30],"155":[156],"157":[156],"158":[156],"159":[26],"160":[26],"29":[27],"31":[30,26],"38":[26],"28":[27],"58":[26],"161":[26],"84":[26],"162":[26],"63":[26],"163":[26],"57":[26],"66":[26],"164":[26],"165":[30,26],"166":[26],"62":[26],"65":[26],"167":[26],"61":[30,26],"70":[26],"168":[24],"169":[24],"25":[24],"170":[24],"171":[19],"172":[19]}

Deserializers.types = ["UnityEngine.Shader","UnityEngine.Transform","UnityEngine.SpriteRenderer","UnityEngine.Sprite","UnityEngine.Material","UnityEngine.MonoBehaviour","HighlightedZone","UnityEngine.Rendering.SortingGroup","UnityEngine.Texture2D","UnityEngine.ParticleSystemRenderer","UnityEngine.ParticleSystem","FogObject","DragObject","UnityEngine.GameObject","UnityEngine.BoxCollider2D","EggBasket","FlyableMergeObject","DecorationObject","GridCell","UnityEngine.Camera","UnityEngine.AudioListener","CameraController","UnityEngine.BoxCollider","UnityEngine.EventSystems.UIBehaviour","UnityEngine.EventSystems.EventSystem","UnityEngine.EventSystems.StandaloneInputModule","UnityEngine.RectTransform","UnityEngine.Canvas","UnityEngine.UI.CanvasScaler","UnityEngine.UI.GraphicRaycaster","UnityEngine.CanvasRenderer","UnityEngine.UI.Image","TMPro.TextMeshProUGUI","TMPro.TMP_FontAsset","UnityEngine.UI.Button","TutorialHandPointer","DinoCarousel","PlayNowButton","UnityEngine.UI.AspectRatioFitter","TutorialHand","ObjectManager","FogManager","MapFogLayoutManager","PointsManager","MapObjectLayoutManager","MainSystem","CustomGridShape","FlyingObjectsManager","DragManager","DinoSelectionManager","FlyingDragManager","ObjectSet","AudioSystem","UnityEngine.AudioSource","UnityEngine.AudioClip","UnityEngine.Cubemap","UnityEngine.Rendering.UI.DebugUIHandlerCanvas","UnityEngine.UI.VerticalLayoutGroup","UnityEngine.UI.ContentSizeFitter","UnityEngine.Rendering.UI.DebugUIHandlerContainer","UnityEngine.Rendering.UI.DebugUIHandlerPanel","UnityEngine.UI.Text","UnityEngine.UI.ScrollRect","UnityEngine.UI.LayoutElement","UnityEngine.Font","UnityEngine.UI.Scrollbar","UnityEngine.UI.Mask","UnityEngine.EventSystems.EventTrigger","UnityEngine.Rendering.UI.DebugUIHandlerValue","UnityEngine.Rendering.UI.DebugUIHandlerToggle","UnityEngine.UI.Toggle","UnityEngine.Rendering.UI.DebugUIHandlerIntField","UnityEngine.Rendering.UI.DebugUIHandlerUIntField","UnityEngine.Rendering.UI.DebugUIHandlerFloatField","UnityEngine.Rendering.UI.DebugUIHandlerEnumField","UnityEngine.Rendering.UI.DebugUIHandlerButton","UnityEngine.Rendering.UI.DebugUIHandlerFoldout","UnityEngine.Rendering.UI.UIFoldout","UnityEngine.Rendering.UI.DebugUIHandlerColor","UnityEngine.Rendering.UI.DebugUIHandlerIndirectFloatField","UnityEngine.Rendering.UI.DebugUIHandlerVector2","UnityEngine.Rendering.UI.DebugUIHandlerVector3","UnityEngine.Rendering.UI.DebugUIHandlerVector4","UnityEngine.Rendering.UI.DebugUIHandlerVBox","UnityEngine.UI.HorizontalLayoutGroup","UnityEngine.Rendering.UI.DebugUIHandlerHBox","UnityEngine.Rendering.UI.DebugUIHandlerGroup","UnityEngine.Rendering.UI.DebugUIHandlerBitField","UnityEngine.Rendering.UI.DebugUIHandlerIndirectToggle","UnityEngine.Rendering.UI.DebugUIHandlerToggleHistory","UnityEngine.Rendering.UI.DebugUIHandlerEnumHistory","UnityEngine.Rendering.UI.DebugUIHandlerRow","UnityEngine.Rendering.UI.DebugUIHandlerMessageBox","UnityEngine.Rendering.UI.DebugUIHandlerProgressBar","UnityEngine.Rendering.UI.DebugUIHandlerValueTuple","UnityEngine.Rendering.UI.DebugUIHandlerObject","UnityEngine.Rendering.UI.DebugUIHandlerObjectList","UnityEngine.Rendering.UI.DebugUIHandlerObjectPopupField","UnityEngine.Rendering.UI.DebugUIHandlerRenderingLayerField","UnityEngine.Rendering.UI.DebugUIHandlerPersistentCanvas","TMPro.TMP_SpriteAsset","TMPro.TMP_StyleSheet","TMPro.TMP_Settings","UnityEngine.TextAsset","UnityEngine.AudioLowPassFilter","UnityEngine.AudioBehaviour","UnityEngine.AudioHighPassFilter","UnityEngine.AudioReverbFilter","UnityEngine.AudioDistortionFilter","UnityEngine.AudioEchoFilter","UnityEngine.AudioChorusFilter","UnityEngine.Cloth","UnityEngine.SkinnedMeshRenderer","UnityEngine.FlareLayer","UnityEngine.CharacterJoint","UnityEngine.Rigidbody","UnityEngine.ConfigurableJoint","UnityEngine.ConstantForce","UnityEngine.FixedJoint","UnityEngine.HingeJoint","UnityEngine.SpringJoint","UnityEngine.CompositeCollider2D","UnityEngine.Rigidbody2D","UnityEngine.Joint2D","UnityEngine.AnchoredJoint2D","UnityEngine.SpringJoint2D","UnityEngine.DistanceJoint2D","UnityEngine.FrictionJoint2D","UnityEngine.HingeJoint2D","UnityEngine.RelativeJoint2D","UnityEngine.SliderJoint2D","UnityEngine.TargetJoint2D","UnityEngine.FixedJoint2D","UnityEngine.WheelJoint2D","UnityEngine.ConstantForce2D","UnityEngine.StreamingController","UnityEngine.TextMesh","UnityEngine.MeshRenderer","UnityEngine.Tilemaps.TilemapRenderer","UnityEngine.Tilemaps.Tilemap","UnityEngine.Tilemaps.TilemapCollider2D","UnityEngine.Renderer","UnityEngine.InputSystem.UI.InputSystemUIInputModule","UnityEngine.InputSystem.UI.TrackedDeviceRaycaster","UnityEngine.Rendering.Universal.PixelPerfectCamera","UnityEngine.Rendering.Universal.UniversalAdditionalCameraData","UnityEngine.Rendering.Universal.UniversalAdditionalLightData","UnityEngine.Light","TMPro.TMP_Dropdown","TMPro.TMP_SelectionCaret","TMPro.TMP_SubMesh","TMPro.TMP_SubMeshUI","TMPro.TMP_Text","TMPro.TextContainer","TMPro.TextMeshPro","Unity.VisualScripting.SceneVariables","Unity.VisualScripting.Variables","Unity.VisualScripting.ScriptMachine","Unity.VisualScripting.StateMachine","UnityEngine.UI.Dropdown","UnityEngine.UI.Graphic","UnityEngine.UI.GridLayoutGroup","UnityEngine.UI.HorizontalOrVerticalLayoutGroup","UnityEngine.UI.LayoutGroup","UnityEngine.UI.MaskableGraphic","UnityEngine.UI.RawImage","UnityEngine.UI.RectMask2D","UnityEngine.UI.Slider","UnityEngine.EventSystems.BaseInputModule","UnityEngine.EventSystems.PointerInputModule","UnityEngine.EventSystems.TouchInputModule","UnityEngine.EventSystems.Physics2DRaycaster","UnityEngine.EventSystems.PhysicsRaycaster"]

Deserializers.unityVersion = "6000.0.84f1";

Deserializers.productName = "Dino Merge";

Deserializers.lunaInitializationTime = "09/17/2026 09:47:36";

Deserializers.lunaDaysRunning = "0.0";

Deserializers.lunaVersion = "7.2.0";

Deserializers.lunaSHA = "ea08d29afe2968efcb8d91d5624f033c6485cc68";

Deserializers.creativeName = "";

Deserializers.lunaAppID = "35797";

Deserializers.projectId = "b9ed475f1d863ed4f92b4c9b93b468c6";

Deserializers.packagesInfo = "com.unity.inputsystem: 1.20.0\ncom.unity.render-pipelines.universal: 17.0.4\ncom.unity.timeline: 1.8.13\ncom.unity.ugui: 2.0.0";

Deserializers.externalJsLibraries = "";

Deserializers.androidLink = ( typeof window !== "undefined")&&window.$environment.packageConfig.androidLink?window.$environment.packageConfig.androidLink:'Empty';

Deserializers.iosLink = ( typeof window !== "undefined")&&window.$environment.packageConfig.iosLink?window.$environment.packageConfig.iosLink:'Empty';

Deserializers.base64Enabled = "False";

Deserializers.minifyEnabled = "True";

Deserializers.isForceUncompressed = "False";

Deserializers.isAntiAliasingEnabled = "False";

Deserializers.isRuntimeAnalysisEnabledForCode = "False";

Deserializers.runtimeAnalysisExcludedClassesCount = "1792";

Deserializers.runtimeAnalysisExcludedMethodsCount = "4659";

Deserializers.runtimeAnalysisExcludedModules = "physics2d, mecanim-wasm";

Deserializers.isRuntimeAnalysisEnabledForShaders = "True";

Deserializers.isRealtimeShadowsEnabled = "False";

Deserializers.isLunaCompilerV2Used = "False";

Deserializers.companyName = "DefaultCompany";

Deserializers.buildPlatform = "StandaloneWindows64";

Deserializers.applicationIdentifier = "com.Unity-Technologies.com.unity.template.urp-blank";

Deserializers.disableAntiAliasing = true;

Deserializers.graphicsConstraint = 24;

Deserializers.linearColorSpace = true;

Deserializers.buildID = "f1e94a51-1561-45ae-a0d2-d6e4b869a2d5";

Deserializers.runtimeInitializeOnLoadInfos = [[["UnityEngine","Rendering","DebugUpdater","RuntimeInit"],["Unity","PerformanceTesting","PerformanceTest","ResetStaticsOnLoad"],["Unity","Burst","BurstCompiler","ResetStaticsOnLoad"],["UnityEngine","Experimental","Rendering","ScriptableRuntimeReflectionSystemSettings","ScriptingDirtyReflectionSystemInstance"]],[["Unity","VisualScripting","GraphReference","ResetStaticsOnLoad"],["Unity","VisualScripting","RuntimeVSUsageUtility","RuntimeInitializeOnLoadBeforeSceneLoad"],["UnityEngine","InputSystem","PlayerInput","InitializeGlobalPlayerState"],["UnityEngine","InputSystem","InputSystem","RuntimeInitialize"],["UnityEngine","InputSystem","InputActionState","InitializeGlobalActionState"],["Unity","AI","Navigation","NavMeshModifierVolume","ClearNavMeshModifiers"],["Unity","AI","Navigation","NavMeshLink","ClearTrackedList"],["Unity","AI","Navigation","NavMeshSurface","ClearNavMeshSurfaces"],["Unity","AI","Navigation","NavMeshModifier","ClearNavMeshModifiers"],["UnityEngine","AI","NavMesh","ClearPreUpdateListeners"]],[["Unity","VisualScripting","Dependencies","NCalc","Expression","ResetStaticsOnLoad"],["Unity","VisualScripting","Flow","ResetStaticsOnLoad"],["Unity","VisualScripting","GraphInstances","ResetStaticsOnLoad"],["Unity","VisualScripting","FullSerializer","fsGlobalConfig","ResetStaticsOnLoad"],["Unity","VisualScripting","RuntimeCodebase","ResetStaticsOnLoad"],["Unity","VisualScripting","FullSerializer","fsAotCompilationManager","ResetStaticsOnLoad"],["Unity","VisualScripting","FullSerializer","fsSerializer","ResetStaticsOnLoad"],["Unity","VisualScripting","EventBus","ResetStaticsOnLoad"],["Unity","VisualScripting","Ensure","ResetStaticsOnLoad"],["Unity","VisualScripting","UnityThread","ResetStaticsOnLoad"],["Unity","VisualScripting","Recursion","ResetStaticsOnLoad"],["Unity","VisualScripting","SavedVariables","ResetStaticsOnLoad"],["Unity","VisualScripting","FullSerializer","fsMetaType","ResetStaticsOnLoad"],["Unity","VisualScripting","FullSerializer","fsResult","ResetStaticsOnLoad"],["Unity","VisualScripting","ApplicationVariables","ResetStaticsOnLoad"],["Unity","VisualScripting","MessageListener","ResetStaticsOnLoad"],["Unity","VisualScripting","Serialization","ResetStaticsOnLoad"],["Unity","VisualScripting","ReferenceCollector","ResetStaticsOnLoad"],["Unity","VisualScripting","OptimizedReflection","ResetStaticsOnLoad"],["Unity","VisualScripting","EditorTimeBinding","ResetStaticsOnLoad"],["Unity","VisualScripting","ProfilingUtility","ResetStaticsOnLoad"],["Unity","VisualScripting","FullSerializer","Internal","fsPortableReflection","ResetStaticsOnLoad"],["$BurstDirectCallInitializer","Initialize"],["$BurstDirectCallInitializer","Initialize"],["$BurstDirectCallInitializer","Initialize"],["$BurstDirectCallInitializer","Initialize"]],[["UnityEngine","Experimental","Rendering","XRSystem","XRSystemInit"]],[["UnityEngine","Timeline","AnimatorBindingCache","ResetStaticsOnLoad"],["UnityEngine","Timeline","TrackAsset","ResetStaticsOnLoad"],["UnityEngine","Timeline","AnimationPreviewUtilities","ResetStaticsOnLoad"],["Unity","PerformanceTesting","Data","RunSettings","ResetStaticsOnLoad"],["Unity","PerformanceTesting","PlayerCallbacks","ResetStaticsOnLoad"],["UnityEngine","InputSystem","Plugins","InputForUI","InputSystemProvider","Bootstrap"],["UnityEngine","InputSystem","EnhancedTouch","Touch","InitializeGlobalTouchState"],["UnityEngine","InputSystem","Users","InputUser","InitializeGlobalUserState"],["UnityEngine","InputSystem","UI","InputSystemUIInputModule","ResetDefaultActions"]]];

Deserializers.typeNameToIdMap = function(){ var i = 0; return Deserializers.types.reduce( function( res, item ) { res[ item ] = i++; return res; }, {} ) }()

