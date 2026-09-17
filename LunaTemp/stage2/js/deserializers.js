var Deserializers = {}
Deserializers["UnityEngine.JointSpring"] = function (request, data, root) {
  var i736 = root || request.c( 'UnityEngine.JointSpring' )
  var i737 = data
  i736.spring = i737[0]
  i736.damper = i737[1]
  i736.targetPosition = i737[2]
  return i736
}

Deserializers["UnityEngine.JointMotor"] = function (request, data, root) {
  var i738 = root || request.c( 'UnityEngine.JointMotor' )
  var i739 = data
  i738.m_TargetVelocity = i739[0]
  i738.m_Force = i739[1]
  i738.m_FreeSpin = i739[2]
  return i738
}

Deserializers["UnityEngine.JointLimits"] = function (request, data, root) {
  var i740 = root || request.c( 'UnityEngine.JointLimits' )
  var i741 = data
  i740.m_Min = i741[0]
  i740.m_Max = i741[1]
  i740.m_Bounciness = i741[2]
  i740.m_BounceMinVelocity = i741[3]
  i740.m_ContactDistance = i741[4]
  i740.minBounce = i741[5]
  i740.maxBounce = i741[6]
  return i740
}

Deserializers["UnityEngine.JointDrive"] = function (request, data, root) {
  var i742 = root || request.c( 'UnityEngine.JointDrive' )
  var i743 = data
  i742.m_PositionSpring = i743[0]
  i742.m_PositionDamper = i743[1]
  i742.m_MaximumForce = i743[2]
  i742.m_UseAcceleration = i743[3]
  return i742
}

Deserializers["UnityEngine.SoftJointLimitSpring"] = function (request, data, root) {
  var i744 = root || request.c( 'UnityEngine.SoftJointLimitSpring' )
  var i745 = data
  i744.m_Spring = i745[0]
  i744.m_Damper = i745[1]
  return i744
}

Deserializers["UnityEngine.SoftJointLimit"] = function (request, data, root) {
  var i746 = root || request.c( 'UnityEngine.SoftJointLimit' )
  var i747 = data
  i746.m_Limit = i747[0]
  i746.m_Bounciness = i747[1]
  i746.m_ContactDistance = i747[2]
  return i746
}

Deserializers["UnityEngine.WheelFrictionCurve"] = function (request, data, root) {
  var i748 = root || request.c( 'UnityEngine.WheelFrictionCurve' )
  var i749 = data
  i748.m_ExtremumSlip = i749[0]
  i748.m_ExtremumValue = i749[1]
  i748.m_AsymptoteSlip = i749[2]
  i748.m_AsymptoteValue = i749[3]
  i748.m_Stiffness = i749[4]
  return i748
}

Deserializers["UnityEngine.JointAngleLimits2D"] = function (request, data, root) {
  var i750 = root || request.c( 'UnityEngine.JointAngleLimits2D' )
  var i751 = data
  i750.m_LowerAngle = i751[0]
  i750.m_UpperAngle = i751[1]
  return i750
}

Deserializers["UnityEngine.JointMotor2D"] = function (request, data, root) {
  var i752 = root || request.c( 'UnityEngine.JointMotor2D' )
  var i753 = data
  i752.m_MotorSpeed = i753[0]
  i752.m_MaximumMotorTorque = i753[1]
  return i752
}

Deserializers["UnityEngine.JointSuspension2D"] = function (request, data, root) {
  var i754 = root || request.c( 'UnityEngine.JointSuspension2D' )
  var i755 = data
  i754.m_DampingRatio = i755[0]
  i754.m_Frequency = i755[1]
  i754.m_Angle = i755[2]
  return i754
}

Deserializers["UnityEngine.JointTranslationLimits2D"] = function (request, data, root) {
  var i756 = root || request.c( 'UnityEngine.JointTranslationLimits2D' )
  var i757 = data
  i756.m_LowerTranslation = i757[0]
  i756.m_UpperTranslation = i757[1]
  return i756
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material"] = function (request, data, root) {
  var i758 = root || new pc.UnityMaterial()
  var i759 = data
  i758.name = i759[0]
  request.r(i759[1], i759[2], 0, i758, 'shader')
  i758.renderQueue = i759[3]
  i758.enableInstancing = !!i759[4]
  var i761 = i759[5]
  var i760 = []
  for(var i = 0; i < i761.length; i += 1) {
    i760.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Material+FloatParameter', i761[i + 0]) );
  }
  i758.floatParameters = i760
  var i763 = i759[6]
  var i762 = []
  for(var i = 0; i < i763.length; i += 1) {
    i762.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Material+ColorParameter', i763[i + 0]) );
  }
  i758.colorParameters = i762
  var i765 = i759[7]
  var i764 = []
  for(var i = 0; i < i765.length; i += 1) {
    i764.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Material+VectorParameter', i765[i + 0]) );
  }
  i758.vectorParameters = i764
  var i767 = i759[8]
  var i766 = []
  for(var i = 0; i < i767.length; i += 1) {
    i766.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Material+TextureParameter', i767[i + 0]) );
  }
  i758.textureParameters = i766
  var i769 = i759[9]
  var i768 = []
  for(var i = 0; i < i769.length; i += 1) {
    i768.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Material+MaterialFlag', i769[i + 0]) );
  }
  i758.materialFlags = i768
  return i758
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material+FloatParameter"] = function (request, data, root) {
  var i772 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Material+FloatParameter' )
  var i773 = data
  i772.name = i773[0]
  i772.value = i773[1]
  return i772
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material+ColorParameter"] = function (request, data, root) {
  var i776 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Material+ColorParameter' )
  var i777 = data
  i776.name = i777[0]
  i776.value = new pc.Color(i777[1], i777[2], i777[3], i777[4])
  return i776
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material+VectorParameter"] = function (request, data, root) {
  var i780 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Material+VectorParameter' )
  var i781 = data
  i780.name = i781[0]
  i780.value = new pc.Vec4( i781[1], i781[2], i781[3], i781[4] )
  return i780
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material+TextureParameter"] = function (request, data, root) {
  var i784 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Material+TextureParameter' )
  var i785 = data
  i784.name = i785[0]
  request.r(i785[1], i785[2], 0, i784, 'value')
  return i784
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material+MaterialFlag"] = function (request, data, root) {
  var i788 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Material+MaterialFlag' )
  var i789 = data
  i788.name = i789[0]
  i788.enabled = !!i789[1]
  return i788
}

Deserializers["Luna.Unity.DTO.UnityEngine.Textures.Texture2D"] = function (request, data, root) {
  var i790 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Textures.Texture2D' )
  var i791 = data
  i790.name = i791[0]
  i790.width = i791[1]
  i790.height = i791[2]
  i790.mipmapCount = i791[3]
  i790.anisoLevel = i791[4]
  i790.filterMode = i791[5]
  i790.hdr = !!i791[6]
  i790.format = i791[7]
  i790.wrapMode = i791[8]
  i790.alphaIsTransparency = !!i791[9]
  i790.alphaSource = i791[10]
  i790.graphicsFormat = i791[11]
  i790.sRGBTexture = !!i791[12]
  i790.desiredColorSpace = i791[13]
  i790.wrapU = i791[14]
  i790.wrapV = i791[15]
  return i790
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.Transform"] = function (request, data, root) {
  var i792 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.Transform' )
  var i793 = data
  i792.position = new pc.Vec3( i793[0], i793[1], i793[2] )
  i792.scale = new pc.Vec3( i793[3], i793[4], i793[5] )
  i792.rotation = new pc.Quat(i793[6], i793[7], i793[8], i793[9])
  return i792
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.SpriteRenderer"] = function (request, data, root) {
  var i794 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.SpriteRenderer' )
  var i795 = data
  i794.color = new pc.Color(i795[0], i795[1], i795[2], i795[3])
  request.r(i795[4], i795[5], 0, i794, 'sprite')
  i794.flipX = !!i795[6]
  i794.flipY = !!i795[7]
  i794.drawMode = i795[8]
  i794.size = new pc.Vec2( i795[9], i795[10] )
  i794.tileMode = i795[11]
  i794.adaptiveModeThreshold = i795[12]
  i794.maskInteraction = i795[13]
  i794.spriteSortPoint = i795[14]
  i794.enabled = !!i795[15]
  request.r(i795[16], i795[17], 0, i794, 'sharedMaterial')
  var i797 = i795[18]
  var i796 = []
  for(var i = 0; i < i797.length; i += 2) {
  request.r(i797[i + 0], i797[i + 1], 2, i796, '')
  }
  i794.sharedMaterials = i796
  i794.receiveShadows = !!i795[19]
  i794.shadowCastingMode = i795[20]
  i794.sortingLayerID = i795[21]
  i794.sortingOrder = i795[22]
  i794.lightmapIndex = i795[23]
  i794.lightmapSceneIndex = i795[24]
  i794.lightmapScaleOffset = new pc.Vec4( i795[25], i795[26], i795[27], i795[28] )
  i794.lightProbeUsage = i795[29]
  i794.reflectionProbeUsage = i795[30]
  return i794
}

Deserializers["HighlightedZone"] = function (request, data, root) {
  var i800 = root || request.c( 'HighlightedZone' )
  var i801 = data
  return i800
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.SortingGroup"] = function (request, data, root) {
  var i802 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.SortingGroup' )
  var i803 = data
  i802.sortingLayerIndex = i803[0]
  i802.sortingOrder = i803[1]
  i802.sortingLayerName = i803[2]
  i802.enabled = !!i803[3]
  return i802
}

Deserializers["Luna.Unity.DTO.UnityEngine.Scene.GameObject"] = function (request, data, root) {
  var i804 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Scene.GameObject' )
  var i805 = data
  i804.name = i805[0]
  i804.tagId = i805[1]
  i804.enabled = !!i805[2]
  i804.isStatic = !!i805[3]
  i804.layer = i805[4]
  return i804
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.ParticleSystemRenderer"] = function (request, data, root) {
  var i806 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.ParticleSystemRenderer' )
  var i807 = data
  request.r(i807[0], i807[1], 0, i806, 'mesh')
  i806.meshCount = i807[2]
  i806.activeVertexStreamsCount = i807[3]
  i806.alignment = i807[4]
  i806.renderMode = i807[5]
  i806.sortMode = i807[6]
  i806.lengthScale = i807[7]
  i806.velocityScale = i807[8]
  i806.cameraVelocityScale = i807[9]
  i806.normalDirection = i807[10]
  i806.sortingFudge = i807[11]
  i806.minParticleSize = i807[12]
  i806.maxParticleSize = i807[13]
  i806.pivot = new pc.Vec3( i807[14], i807[15], i807[16] )
  request.r(i807[17], i807[18], 0, i806, 'trailMaterial')
  i806.applyActiveColorSpace = !!i807[19]
  i806.enabled = !!i807[20]
  request.r(i807[21], i807[22], 0, i806, 'sharedMaterial')
  var i809 = i807[23]
  var i808 = []
  for(var i = 0; i < i809.length; i += 2) {
  request.r(i809[i + 0], i809[i + 1], 2, i808, '')
  }
  i806.sharedMaterials = i808
  i806.receiveShadows = !!i807[24]
  i806.shadowCastingMode = i807[25]
  i806.sortingLayerID = i807[26]
  i806.sortingOrder = i807[27]
  i806.lightmapIndex = i807[28]
  i806.lightmapSceneIndex = i807[29]
  i806.lightmapScaleOffset = new pc.Vec4( i807[30], i807[31], i807[32], i807[33] )
  i806.lightProbeUsage = i807[34]
  i806.reflectionProbeUsage = i807[35]
  return i806
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.ParticleSystem"] = function (request, data, root) {
  var i810 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.ParticleSystem' )
  var i811 = data
  i810.main = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.MainModule', i811[0], i810.main)
  i810.colorBySpeed = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ColorBySpeedModule', i811[1], i810.colorBySpeed)
  i810.colorOverLifetime = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ColorOverLifetimeModule', i811[2], i810.colorOverLifetime)
  i810.emission = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.EmissionModule', i811[3], i810.emission)
  i810.rotationBySpeed = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.RotationBySpeedModule', i811[4], i810.rotationBySpeed)
  i810.rotationOverLifetime = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.RotationOverLifetimeModule', i811[5], i810.rotationOverLifetime)
  i810.shape = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ShapeModule', i811[6], i810.shape)
  i810.sizeBySpeed = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.SizeBySpeedModule', i811[7], i810.sizeBySpeed)
  i810.sizeOverLifetime = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.SizeOverLifetimeModule', i811[8], i810.sizeOverLifetime)
  i810.textureSheetAnimation = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.TextureSheetAnimationModule', i811[9], i810.textureSheetAnimation)
  i810.velocityOverLifetime = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.VelocityOverLifetimeModule', i811[10], i810.velocityOverLifetime)
  i810.noise = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.NoiseModule', i811[11], i810.noise)
  i810.inheritVelocity = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.InheritVelocityModule', i811[12], i810.inheritVelocity)
  i810.forceOverLifetime = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ForceOverLifetimeModule', i811[13], i810.forceOverLifetime)
  i810.limitVelocityOverLifetime = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.LimitVelocityOverLifetimeModule', i811[14], i810.limitVelocityOverLifetime)
  i810.useAutoRandomSeed = !!i811[15]
  i810.randomSeed = i811[16]
  return i810
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.MainModule"] = function (request, data, root) {
  var i812 = root || new pc.ParticleSystemMain()
  var i813 = data
  i812.duration = i813[0]
  i812.loop = !!i813[1]
  i812.prewarm = !!i813[2]
  i812.startDelay = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i813[3], i812.startDelay)
  i812.startLifetime = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i813[4], i812.startLifetime)
  i812.startSpeed = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i813[5], i812.startSpeed)
  i812.startSize3D = !!i813[6]
  i812.startSizeX = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i813[7], i812.startSizeX)
  i812.startSizeY = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i813[8], i812.startSizeY)
  i812.startSizeZ = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i813[9], i812.startSizeZ)
  i812.startRotation3D = !!i813[10]
  i812.startRotationX = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i813[11], i812.startRotationX)
  i812.startRotationY = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i813[12], i812.startRotationY)
  i812.startRotationZ = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i813[13], i812.startRotationZ)
  i812.startColor = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxGradient', i813[14], i812.startColor)
  i812.gravityModifier = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i813[15], i812.gravityModifier)
  i812.simulationSpace = i813[16]
  request.r(i813[17], i813[18], 0, i812, 'customSimulationSpace')
  i812.simulationSpeed = i813[19]
  i812.useUnscaledTime = !!i813[20]
  i812.scalingMode = i813[21]
  i812.playOnAwake = !!i813[22]
  i812.maxParticles = i813[23]
  i812.emitterVelocityMode = i813[24]
  i812.stopAction = i813[25]
  return i812
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve"] = function (request, data, root) {
  var i814 = root || new pc.MinMaxCurve()
  var i815 = data
  i814.mode = i815[0]
  i814.curveMin = new pc.AnimationCurve( { keys_flow: i815[1] } )
  i814.curveMax = new pc.AnimationCurve( { keys_flow: i815[2] } )
  i814.curveMultiplier = i815[3]
  i814.constantMin = i815[4]
  i814.constantMax = i815[5]
  return i814
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxGradient"] = function (request, data, root) {
  var i816 = root || new pc.MinMaxGradient()
  var i817 = data
  i816.mode = i817[0]
  i816.gradientMin = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Gradient', i817[1], i816.gradientMin)
  i816.gradientMax = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Gradient', i817[2], i816.gradientMax)
  i816.colorMin = new pc.Color(i817[3], i817[4], i817[5], i817[6])
  i816.colorMax = new pc.Color(i817[7], i817[8], i817[9], i817[10])
  return i816
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Gradient"] = function (request, data, root) {
  var i818 = root || request.c( 'Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Gradient' )
  var i819 = data
  i818.mode = i819[0]
  var i821 = i819[1]
  var i820 = []
  for(var i = 0; i < i821.length; i += 1) {
    i820.push( request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Data.GradientColorKey', i821[i + 0]) );
  }
  i818.colorKeys = i820
  var i823 = i819[2]
  var i822 = []
  for(var i = 0; i < i823.length; i += 1) {
    i822.push( request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Data.GradientAlphaKey', i823[i + 0]) );
  }
  i818.alphaKeys = i822
  return i818
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ColorBySpeedModule"] = function (request, data, root) {
  var i824 = root || new pc.ParticleSystemColorBySpeed()
  var i825 = data
  i824.enabled = !!i825[0]
  i824.color = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxGradient', i825[1], i824.color)
  i824.range = new pc.Vec2( i825[2], i825[3] )
  return i824
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Data.GradientColorKey"] = function (request, data, root) {
  var i828 = root || request.c( 'Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Data.GradientColorKey' )
  var i829 = data
  i828.color = new pc.Color(i829[0], i829[1], i829[2], i829[3])
  i828.time = i829[4]
  return i828
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Data.GradientAlphaKey"] = function (request, data, root) {
  var i832 = root || request.c( 'Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Data.GradientAlphaKey' )
  var i833 = data
  i832.alpha = i833[0]
  i832.time = i833[1]
  return i832
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ColorOverLifetimeModule"] = function (request, data, root) {
  var i834 = root || new pc.ParticleSystemColorOverLifetime()
  var i835 = data
  i834.enabled = !!i835[0]
  i834.color = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxGradient', i835[1], i834.color)
  return i834
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.EmissionModule"] = function (request, data, root) {
  var i836 = root || new pc.ParticleSystemEmitter()
  var i837 = data
  i836.enabled = !!i837[0]
  i836.rateOverTime = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i837[1], i836.rateOverTime)
  i836.rateOverDistance = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i837[2], i836.rateOverDistance)
  var i839 = i837[3]
  var i838 = []
  for(var i = 0; i < i839.length; i += 1) {
    i838.push( request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Burst', i839[i + 0]) );
  }
  i836.bursts = i838
  return i836
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Burst"] = function (request, data, root) {
  var i842 = root || new pc.ParticleSystemBurst()
  var i843 = data
  i842.count = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i843[0], i842.count)
  i842.cycleCount = i843[1]
  i842.minCount = i843[2]
  i842.maxCount = i843[3]
  i842.repeatInterval = i843[4]
  i842.time = i843[5]
  return i842
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.RotationBySpeedModule"] = function (request, data, root) {
  var i844 = root || new pc.ParticleSystemRotationBySpeed()
  var i845 = data
  i844.enabled = !!i845[0]
  i844.x = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i845[1], i844.x)
  i844.y = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i845[2], i844.y)
  i844.z = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i845[3], i844.z)
  i844.separateAxes = !!i845[4]
  i844.range = new pc.Vec2( i845[5], i845[6] )
  return i844
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.RotationOverLifetimeModule"] = function (request, data, root) {
  var i846 = root || new pc.ParticleSystemRotationOverLifetime()
  var i847 = data
  i846.enabled = !!i847[0]
  i846.x = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i847[1], i846.x)
  i846.y = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i847[2], i846.y)
  i846.z = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i847[3], i846.z)
  i846.separateAxes = !!i847[4]
  return i846
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ShapeModule"] = function (request, data, root) {
  var i848 = root || new pc.ParticleSystemShape()
  var i849 = data
  i848.enabled = !!i849[0]
  i848.shapeType = i849[1]
  i848.randomDirectionAmount = i849[2]
  i848.sphericalDirectionAmount = i849[3]
  i848.randomPositionAmount = i849[4]
  i848.alignToDirection = !!i849[5]
  i848.radius = i849[6]
  i848.radiusMode = i849[7]
  i848.radiusSpread = i849[8]
  i848.radiusSpeed = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i849[9], i848.radiusSpeed)
  i848.radiusThickness = i849[10]
  i848.angle = i849[11]
  i848.length = i849[12]
  i848.boxThickness = new pc.Vec3( i849[13], i849[14], i849[15] )
  i848.meshShapeType = i849[16]
  request.r(i849[17], i849[18], 0, i848, 'mesh')
  request.r(i849[19], i849[20], 0, i848, 'meshRenderer')
  request.r(i849[21], i849[22], 0, i848, 'skinnedMeshRenderer')
  i848.useMeshMaterialIndex = !!i849[23]
  i848.meshMaterialIndex = i849[24]
  i848.useMeshColors = !!i849[25]
  i848.normalOffset = i849[26]
  i848.arc = i849[27]
  i848.arcMode = i849[28]
  i848.arcSpread = i849[29]
  i848.arcSpeed = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i849[30], i848.arcSpeed)
  i848.donutRadius = i849[31]
  i848.position = new pc.Vec3( i849[32], i849[33], i849[34] )
  i848.rotation = new pc.Vec3( i849[35], i849[36], i849[37] )
  i848.scale = new pc.Vec3( i849[38], i849[39], i849[40] )
  return i848
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.SizeBySpeedModule"] = function (request, data, root) {
  var i850 = root || new pc.ParticleSystemSizeBySpeed()
  var i851 = data
  i850.enabled = !!i851[0]
  i850.x = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i851[1], i850.x)
  i850.y = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i851[2], i850.y)
  i850.z = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i851[3], i850.z)
  i850.separateAxes = !!i851[4]
  i850.range = new pc.Vec2( i851[5], i851[6] )
  return i850
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.SizeOverLifetimeModule"] = function (request, data, root) {
  var i852 = root || new pc.ParticleSystemSizeOverLifetime()
  var i853 = data
  i852.enabled = !!i853[0]
  i852.x = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i853[1], i852.x)
  i852.y = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i853[2], i852.y)
  i852.z = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i853[3], i852.z)
  i852.separateAxes = !!i853[4]
  return i852
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.TextureSheetAnimationModule"] = function (request, data, root) {
  var i854 = root || new pc.ParticleSystemTextureSheetAnimation()
  var i855 = data
  i854.enabled = !!i855[0]
  i854.mode = i855[1]
  i854.animation = i855[2]
  i854.numTilesX = i855[3]
  i854.numTilesY = i855[4]
  i854.useRandomRow = !!i855[5]
  i854.frameOverTime = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i855[6], i854.frameOverTime)
  i854.startFrame = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i855[7], i854.startFrame)
  i854.cycleCount = i855[8]
  i854.rowIndex = i855[9]
  i854.flipU = i855[10]
  i854.flipV = i855[11]
  i854.spriteCount = i855[12]
  var i857 = i855[13]
  var i856 = []
  for(var i = 0; i < i857.length; i += 2) {
  request.r(i857[i + 0], i857[i + 1], 2, i856, '')
  }
  i854.sprites = i856
  return i854
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.VelocityOverLifetimeModule"] = function (request, data, root) {
  var i860 = root || new pc.ParticleSystemVelocityOverLifetime()
  var i861 = data
  i860.enabled = !!i861[0]
  i860.x = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i861[1], i860.x)
  i860.y = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i861[2], i860.y)
  i860.z = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i861[3], i860.z)
  i860.radial = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i861[4], i860.radial)
  i860.speedModifier = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i861[5], i860.speedModifier)
  i860.space = i861[6]
  i860.orbitalX = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i861[7], i860.orbitalX)
  i860.orbitalY = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i861[8], i860.orbitalY)
  i860.orbitalZ = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i861[9], i860.orbitalZ)
  i860.orbitalOffsetX = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i861[10], i860.orbitalOffsetX)
  i860.orbitalOffsetY = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i861[11], i860.orbitalOffsetY)
  i860.orbitalOffsetZ = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i861[12], i860.orbitalOffsetZ)
  return i860
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.NoiseModule"] = function (request, data, root) {
  var i862 = root || new pc.ParticleSystemNoise()
  var i863 = data
  i862.enabled = !!i863[0]
  i862.separateAxes = !!i863[1]
  i862.strengthX = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i863[2], i862.strengthX)
  i862.strengthY = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i863[3], i862.strengthY)
  i862.strengthZ = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i863[4], i862.strengthZ)
  i862.frequency = i863[5]
  i862.damping = !!i863[6]
  i862.octaveCount = i863[7]
  i862.octaveMultiplier = i863[8]
  i862.octaveScale = i863[9]
  i862.quality = i863[10]
  i862.scrollSpeed = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i863[11], i862.scrollSpeed)
  i862.scrollSpeedMultiplier = i863[12]
  i862.remapEnabled = !!i863[13]
  i862.remapX = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i863[14], i862.remapX)
  i862.remapY = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i863[15], i862.remapY)
  i862.remapZ = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i863[16], i862.remapZ)
  i862.positionAmount = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i863[17], i862.positionAmount)
  i862.rotationAmount = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i863[18], i862.rotationAmount)
  i862.sizeAmount = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i863[19], i862.sizeAmount)
  return i862
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.InheritVelocityModule"] = function (request, data, root) {
  var i864 = root || new pc.ParticleSystemInheritVelocity()
  var i865 = data
  i864.enabled = !!i865[0]
  i864.mode = i865[1]
  i864.curve = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i865[2], i864.curve)
  return i864
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ForceOverLifetimeModule"] = function (request, data, root) {
  var i866 = root || new pc.ParticleSystemForceOverLifetime()
  var i867 = data
  i866.enabled = !!i867[0]
  i866.x = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i867[1], i866.x)
  i866.y = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i867[2], i866.y)
  i866.z = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i867[3], i866.z)
  i866.space = i867[4]
  i866.randomized = !!i867[5]
  return i866
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.LimitVelocityOverLifetimeModule"] = function (request, data, root) {
  var i868 = root || new pc.ParticleSystemLimitVelocityOverLifetime()
  var i869 = data
  i868.enabled = !!i869[0]
  i868.limit = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i869[1], i868.limit)
  i868.limitX = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i869[2], i868.limitX)
  i868.limitY = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i869[3], i868.limitY)
  i868.limitZ = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i869[4], i868.limitZ)
  i868.dampen = i869[5]
  i868.separateAxes = !!i869[6]
  i868.space = i869[7]
  i868.drag = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i869[8], i868.drag)
  i868.multiplyDragByParticleSize = !!i869[9]
  i868.multiplyDragByParticleVelocity = !!i869[10]
  return i868
}

Deserializers["FogObject"] = function (request, data, root) {
  var i870 = root || request.c( 'FogObject' )
  var i871 = data
  i870.m_revealDuration = i871[0]
  i870.m_hideDuration = i871[1]
  request.r(i871[2], i871[3], 0, i870, 'm_revealParticles')
  request.r(i871[4], i871[5], 0, i870, 'm_hideParticles')
  request.r(i871[6], i871[7], 0, i870, 'm_revealSound')
  request.r(i871[8], i871[9], 0, i870, 'm_hideSound')
  request.r(i871[10], i871[11], 0, i870, 'm_fogRenderer')
  i870.m_moveDuration = i871[12]
  return i870
}

Deserializers["DragObject"] = function (request, data, root) {
  var i872 = root || request.c( 'DragObject' )
  var i873 = data
  request.r(i873[0], i873[1], 0, i872, 'm_eggBasket')
  request.r(i873[2], i873[3], 0, i872, 'm_indicatorObject')
  i872.m_objectType = i873[4]
  i872.m_level = i873[5]
  i872.m_canBeMerged = !!i873[6]
  i872.m_mergeValue = i873[7]
  i872.m_mergeThreshold = i873[8]
  i872.m_canBeDragged = !!i873[9]
  request.r(i873[10], i873[11], 0, i872, 'm_objectCollider')
  i872.m_nextLevelType = i873[12]
  i872.m_nextObjectCountToSpawn = i873[13]
  i872.m_moveDuration = i873[14]
  i872.m_pullDelta = i873[15]
  i872.m_pullTime = i873[16]
  request.r(i873[17], i873[18], 0, i872, 'm_spriteRenderer')
  i872.m_height = i873[19]
  i872.m_duration = i873[20]
  i872.m_easeType = i873[21]
  i872.m_loops = i873[22]
  i872.m_loopType = i873[23]
  i872.m_isDragObjectBouncingInAir = !!i873[24]
  i872.m_isMergeOnPlace = !!i873[25]
  i872.m_isMergeThisObjectRevealFog = !!i873[26]
  return i872
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.BoxCollider2D"] = function (request, data, root) {
  var i874 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.BoxCollider2D' )
  var i875 = data
  i874.usedByComposite = !!i875[0]
  i874.autoTiling = !!i875[1]
  i874.size = new pc.Vec2( i875[2], i875[3] )
  i874.edgeRadius = i875[4]
  i874.enabled = !!i875[5]
  i874.isTrigger = !!i875[6]
  i874.usedByEffector = !!i875[7]
  i874.density = i875[8]
  i874.offset = new pc.Vec2( i875[9], i875[10] )
  request.r(i875[11], i875[12], 0, i874, 'material')
  return i874
}

Deserializers["EggBasket"] = function (request, data, root) {
  var i876 = root || request.c( 'EggBasket' )
  var i877 = data
  request.r(i877[0], i877[1], 0, i876, 'm_thisDragObject')
  i876.m_eggGenericId = i877[2]
  i876.m_eggCountToSpawn = i877[3]
  var i879 = i877[4]
  var i878 = []
  for(var i = 0; i < i879.length; i += 2) {
    i878.push( new pc.Vec2( i879[i + 0], i879[i + 1] ) );
  }
  i876.m_spawnPositions = i878
  return i876
}

Deserializers["FlyableMergeObject"] = function (request, data, root) {
  var i882 = root || request.c( 'FlyableMergeObject' )
  var i883 = data
  request.r(i883[0], i883[1], 0, i882, 'm_indicatorObject')
  i882.m_pullDelta = i883[2]
  i882.m_pullTime = i883[3]
  i882.m_objectType = i883[4]
  i882.m_moveSpeed = i883[5]
  i882.m_delayBetweenMoves = i883[6]
  i882.m_mergeThreshold = i883[7]
  request.r(i883[8], i883[9], 0, i882, 'm_boxCollider2D')
  i882.m_level = i883[10]
  i882.m_canBeMerged = !!i883[11]
  i882.m_nextLevelType = i883[12]
  i882.m_nextObjectCountToSpawn = i883[13]
  return i882
}

Deserializers["DecorationObject"] = function (request, data, root) {
  var i884 = root || request.c( 'DecorationObject' )
  var i885 = data
  i884.m_objectType = i885[0]
  return i884
}

Deserializers["GridCell"] = function (request, data, root) {
  var i886 = root || request.c( 'GridCell' )
  var i887 = data
  request.r(i887[0], i887[1], 0, i886, 'm_leftWall')
  request.r(i887[2], i887[3], 0, i886, 'm_rightWall')
  request.r(i887[4], i887[5], 0, i886, 'm_topWall')
  request.r(i887[6], i887[7], 0, i886, 'm_bottomWall')
  request.r(i887[8], i887[9], 0, i886, 'm_downSide_left')
  request.r(i887[10], i887[11], 0, i886, 'm_downSide_down')
  return i886
}

Deserializers["Luna.Unity.DTO.UnityEngine.Textures.Cubemap"] = function (request, data, root) {
  var i888 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Textures.Cubemap' )
  var i889 = data
  i888.name = i889[0]
  i888.atlasId = i889[1]
  i888.mipmapCount = i889[2]
  i888.hdr = !!i889[3]
  i888.size = i889[4]
  i888.anisoLevel = i889[5]
  i888.filterMode = i889[6]
  var i891 = i889[7]
  var i890 = []
  for(var i = 0; i < i891.length; i += 4) {
    i890.push( UnityEngine.Rect.MinMaxRect(i891[i + 0], i891[i + 1], i891[i + 2], i891[i + 3]) );
  }
  i888.rects = i890
  i888.wrapU = i889[8]
  i888.wrapV = i889[9]
  return i888
}

Deserializers["Luna.Unity.DTO.UnityEngine.Scene.Scene"] = function (request, data, root) {
  var i894 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Scene.Scene' )
  var i895 = data
  i894.name = i895[0]
  i894.index = i895[1]
  i894.startup = !!i895[2]
  return i894
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.Camera"] = function (request, data, root) {
  var i896 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.Camera' )
  var i897 = data
  i896.aspect = i897[0]
  i896.orthographic = !!i897[1]
  i896.orthographicSize = i897[2]
  i896.backgroundColor = new pc.Color(i897[3], i897[4], i897[5], i897[6])
  i896.nearClipPlane = i897[7]
  i896.farClipPlane = i897[8]
  i896.fieldOfView = i897[9]
  i896.depth = i897[10]
  i896.clearFlags = i897[11]
  i896.cullingMask = i897[12]
  i896.rect = i897[13]
  request.r(i897[14], i897[15], 0, i896, 'targetTexture')
  i896.usePhysicalProperties = !!i897[16]
  i896.focalLength = i897[17]
  i896.sensorSize = new pc.Vec2( i897[18], i897[19] )
  i896.lensShift = new pc.Vec2( i897[20], i897[21] )
  i896.gateFit = i897[22]
  i896.commandBufferCount = i897[23]
  i896.cameraType = i897[24]
  i896.enabled = !!i897[25]
  return i896
}

Deserializers["CameraController"] = function (request, data, root) {
  var i898 = root || request.c( 'CameraController' )
  var i899 = data
  request.r(i899[0], i899[1], 0, i898, 'm_movingBounds')
  request.r(i899[2], i899[3], 0, i898, 'm_initPoint')
  i898.m_zoomMin = i899[4]
  i898.m_zoomMax = i899[5]
  i898.m_zoomSens = i899[6]
  i898.m_zoomSmooth = i899[7]
  i898.m_defaultZoom = i899[8]
  i898.m_movingSens = i899[9]
  i898.m_movingSmoothness = i899[10]
  i898.m_tapThreshold = i899[11]
  i898.m_inertiaSmoothness = i899[12]
  i898.m_initialInertiaModifier = i899[13]
  i898.m_canDrag = !!i899[14]
  i898.m_stopInertia = !!i899[15]
  request.r(i899[16], i899[17], 0, i898, 'm_mainCamera')
  i898.m_zoomSpeed = i899[18]
  i898.m_zoomDifferenceLimits = new pc.Vec2( i899[19], i899[20] )
  return i898
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.BoxCollider"] = function (request, data, root) {
  var i900 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.BoxCollider' )
  var i901 = data
  i900.center = new pc.Vec3( i901[0], i901[1], i901[2] )
  i900.size = new pc.Vec3( i901[3], i901[4], i901[5] )
  i900.enabled = !!i901[6]
  i900.isTrigger = !!i901[7]
  request.r(i901[8], i901[9], 0, i900, 'material')
  return i900
}

Deserializers["UnityEngine.EventSystems.EventSystem"] = function (request, data, root) {
  var i902 = root || request.c( 'UnityEngine.EventSystems.EventSystem' )
  var i903 = data
  request.r(i903[0], i903[1], 0, i902, 'm_FirstSelected')
  i902.m_sendNavigationEvents = !!i903[2]
  i902.m_DragThreshold = i903[3]
  return i902
}

Deserializers["UnityEngine.EventSystems.StandaloneInputModule"] = function (request, data, root) {
  var i904 = root || request.c( 'UnityEngine.EventSystems.StandaloneInputModule' )
  var i905 = data
  i904.m_HorizontalAxis = i905[0]
  i904.m_VerticalAxis = i905[1]
  i904.m_SubmitButton = i905[2]
  i904.m_CancelButton = i905[3]
  i904.m_InputActionsPerSecond = i905[4]
  i904.m_RepeatDelay = i905[5]
  i904.m_ForceModuleActive = !!i905[6]
  i904.m_SendPointerHoverToParent = !!i905[7]
  return i904
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.RectTransform"] = function (request, data, root) {
  var i906 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.RectTransform' )
  var i907 = data
  i906.pivot = new pc.Vec2( i907[0], i907[1] )
  i906.anchorMin = new pc.Vec2( i907[2], i907[3] )
  i906.anchorMax = new pc.Vec2( i907[4], i907[5] )
  i906.sizeDelta = new pc.Vec2( i907[6], i907[7] )
  i906.anchoredPosition3D = new pc.Vec3( i907[8], i907[9], i907[10] )
  i906.rotation = new pc.Quat(i907[11], i907[12], i907[13], i907[14])
  i906.scale = new pc.Vec3( i907[15], i907[16], i907[17] )
  return i906
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.Canvas"] = function (request, data, root) {
  var i908 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.Canvas' )
  var i909 = data
  i908.planeDistance = i909[0]
  i908.referencePixelsPerUnit = i909[1]
  i908.isFallbackOverlay = !!i909[2]
  i908.renderMode = i909[3]
  i908.renderOrder = i909[4]
  i908.sortingLayerName = i909[5]
  i908.sortingOrder = i909[6]
  i908.scaleFactor = i909[7]
  request.r(i909[8], i909[9], 0, i908, 'worldCamera')
  i908.overrideSorting = !!i909[10]
  i908.pixelPerfect = !!i909[11]
  i908.targetDisplay = i909[12]
  i908.overridePixelPerfect = !!i909[13]
  i908.enabled = !!i909[14]
  return i908
}

Deserializers["UnityEngine.UI.CanvasScaler"] = function (request, data, root) {
  var i910 = root || request.c( 'UnityEngine.UI.CanvasScaler' )
  var i911 = data
  i910.m_UiScaleMode = i911[0]
  i910.m_ReferencePixelsPerUnit = i911[1]
  i910.m_ScaleFactor = i911[2]
  i910.m_ReferenceResolution = new pc.Vec2( i911[3], i911[4] )
  i910.m_ScreenMatchMode = i911[5]
  i910.m_MatchWidthOrHeight = i911[6]
  i910.m_PhysicalUnit = i911[7]
  i910.m_FallbackScreenDPI = i911[8]
  i910.m_DefaultSpriteDPI = i911[9]
  i910.m_DynamicPixelsPerUnit = i911[10]
  i910.m_PresetInfoIsWorld = !!i911[11]
  return i910
}

Deserializers["UnityEngine.UI.GraphicRaycaster"] = function (request, data, root) {
  var i912 = root || request.c( 'UnityEngine.UI.GraphicRaycaster' )
  var i913 = data
  i912.m_IgnoreReversedGraphics = !!i913[0]
  i912.m_BlockingObjects = i913[1]
  i912.m_BlockingMask = UnityEngine.LayerMask.FromIntegerValue( i913[2] )
  return i912
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.CanvasRenderer"] = function (request, data, root) {
  var i914 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.CanvasRenderer' )
  var i915 = data
  i914.cullTransparentMesh = !!i915[0]
  return i914
}

Deserializers["UnityEngine.UI.Image"] = function (request, data, root) {
  var i916 = root || request.c( 'UnityEngine.UI.Image' )
  var i917 = data
  request.r(i917[0], i917[1], 0, i916, 'm_Sprite')
  i916.m_Type = i917[2]
  i916.m_PreserveAspect = !!i917[3]
  i916.m_FillCenter = !!i917[4]
  i916.m_FillMethod = i917[5]
  i916.m_FillAmount = i917[6]
  i916.m_FillClockwise = !!i917[7]
  i916.m_FillOrigin = i917[8]
  i916.m_UseSpriteMesh = !!i917[9]
  i916.m_PixelsPerUnitMultiplier = i917[10]
  request.r(i917[11], i917[12], 0, i916, 'm_Material')
  i916.m_Maskable = !!i917[13]
  i916.m_Color = new pc.Color(i917[14], i917[15], i917[16], i917[17])
  i916.m_RaycastTarget = !!i917[18]
  i916.m_RaycastPadding = new pc.Vec4( i917[19], i917[20], i917[21], i917[22] )
  return i916
}

Deserializers["UnityEngine.UI.Button"] = function (request, data, root) {
  var i918 = root || request.c( 'UnityEngine.UI.Button' )
  var i919 = data
  i918.m_OnClick = request.d('UnityEngine.UI.Button+ButtonClickedEvent', i919[0], i918.m_OnClick)
  i918.m_Navigation = request.d('UnityEngine.UI.Navigation', i919[1], i918.m_Navigation)
  i918.m_Transition = i919[2]
  i918.m_Colors = request.d('UnityEngine.UI.ColorBlock', i919[3], i918.m_Colors)
  i918.m_SpriteState = request.d('UnityEngine.UI.SpriteState', i919[4], i918.m_SpriteState)
  i918.m_AnimationTriggers = request.d('UnityEngine.UI.AnimationTriggers', i919[5], i918.m_AnimationTriggers)
  i918.m_Interactable = !!i919[6]
  request.r(i919[7], i919[8], 0, i918, 'm_TargetGraphic')
  return i918
}

Deserializers["UnityEngine.UI.Button+ButtonClickedEvent"] = function (request, data, root) {
  var i920 = root || request.c( 'UnityEngine.UI.Button+ButtonClickedEvent' )
  var i921 = data
  i920.m_PersistentCalls = request.d('UnityEngine.Events.PersistentCallGroup', i921[0], i920.m_PersistentCalls)
  return i920
}

Deserializers["UnityEngine.Events.PersistentCallGroup"] = function (request, data, root) {
  var i922 = root || request.c( 'UnityEngine.Events.PersistentCallGroup' )
  var i923 = data
  var i925 = i923[0]
  var i924 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.Events.PersistentCall')))
  for(var i = 0; i < i925.length; i += 1) {
    i924.add(request.d('UnityEngine.Events.PersistentCall', i925[i + 0]));
  }
  i922.m_Calls = i924
  return i922
}

Deserializers["UnityEngine.Events.PersistentCall"] = function (request, data, root) {
  var i928 = root || request.c( 'UnityEngine.Events.PersistentCall' )
  var i929 = data
  request.r(i929[0], i929[1], 0, i928, 'm_Target')
  i928.m_TargetAssemblyTypeName = i929[2]
  i928.m_MethodName = i929[3]
  i928.m_Mode = i929[4]
  i928.m_Arguments = request.d('UnityEngine.Events.ArgumentCache', i929[5], i928.m_Arguments)
  i928.m_CallState = i929[6]
  return i928
}

Deserializers["UnityEngine.UI.Navigation"] = function (request, data, root) {
  var i930 = root || request.c( 'UnityEngine.UI.Navigation' )
  var i931 = data
  i930.m_Mode = i931[0]
  i930.m_WrapAround = !!i931[1]
  request.r(i931[2], i931[3], 0, i930, 'm_SelectOnUp')
  request.r(i931[4], i931[5], 0, i930, 'm_SelectOnDown')
  request.r(i931[6], i931[7], 0, i930, 'm_SelectOnLeft')
  request.r(i931[8], i931[9], 0, i930, 'm_SelectOnRight')
  return i930
}

Deserializers["UnityEngine.UI.ColorBlock"] = function (request, data, root) {
  var i932 = root || request.c( 'UnityEngine.UI.ColorBlock' )
  var i933 = data
  i932.m_NormalColor = new pc.Color(i933[0], i933[1], i933[2], i933[3])
  i932.m_HighlightedColor = new pc.Color(i933[4], i933[5], i933[6], i933[7])
  i932.m_PressedColor = new pc.Color(i933[8], i933[9], i933[10], i933[11])
  i932.m_SelectedColor = new pc.Color(i933[12], i933[13], i933[14], i933[15])
  i932.m_DisabledColor = new pc.Color(i933[16], i933[17], i933[18], i933[19])
  i932.m_ColorMultiplier = i933[20]
  i932.m_FadeDuration = i933[21]
  return i932
}

Deserializers["UnityEngine.UI.SpriteState"] = function (request, data, root) {
  var i934 = root || request.c( 'UnityEngine.UI.SpriteState' )
  var i935 = data
  request.r(i935[0], i935[1], 0, i934, 'm_HighlightedSprite')
  request.r(i935[2], i935[3], 0, i934, 'm_PressedSprite')
  request.r(i935[4], i935[5], 0, i934, 'm_SelectedSprite')
  request.r(i935[6], i935[7], 0, i934, 'm_DisabledSprite')
  return i934
}

Deserializers["UnityEngine.UI.AnimationTriggers"] = function (request, data, root) {
  var i936 = root || request.c( 'UnityEngine.UI.AnimationTriggers' )
  var i937 = data
  i936.m_NormalTrigger = i937[0]
  i936.m_HighlightedTrigger = i937[1]
  i936.m_PressedTrigger = i937[2]
  i936.m_SelectedTrigger = i937[3]
  i936.m_DisabledTrigger = i937[4]
  return i936
}

Deserializers["TMPro.TextMeshProUGUI"] = function (request, data, root) {
  var i938 = root || request.c( 'TMPro.TextMeshProUGUI' )
  var i939 = data
  i938.m_hasFontAssetChanged = !!i939[0]
  request.r(i939[1], i939[2], 0, i938, 'm_baseMaterial')
  i938.m_maskOffset = new pc.Vec4( i939[3], i939[4], i939[5], i939[6] )
  i938.m_text = i939[7]
  i938.m_isRightToLeft = !!i939[8]
  request.r(i939[9], i939[10], 0, i938, 'm_fontAsset')
  request.r(i939[11], i939[12], 0, i938, 'm_sharedMaterial')
  var i941 = i939[13]
  var i940 = []
  for(var i = 0; i < i941.length; i += 2) {
  request.r(i941[i + 0], i941[i + 1], 2, i940, '')
  }
  i938.m_fontSharedMaterials = i940
  request.r(i939[14], i939[15], 0, i938, 'm_fontMaterial')
  var i943 = i939[16]
  var i942 = []
  for(var i = 0; i < i943.length; i += 2) {
  request.r(i943[i + 0], i943[i + 1], 2, i942, '')
  }
  i938.m_fontMaterials = i942
  i938.m_fontColor32 = UnityEngine.Color32.ConstructColor(i939[17], i939[18], i939[19], i939[20])
  i938.m_fontColor = new pc.Color(i939[21], i939[22], i939[23], i939[24])
  i938.m_enableVertexGradient = !!i939[25]
  i938.m_colorMode = i939[26]
  i938.m_fontColorGradient = request.d('TMPro.VertexGradient', i939[27], i938.m_fontColorGradient)
  request.r(i939[28], i939[29], 0, i938, 'm_fontColorGradientPreset')
  request.r(i939[30], i939[31], 0, i938, 'm_spriteAsset')
  i938.m_tintAllSprites = !!i939[32]
  request.r(i939[33], i939[34], 0, i938, 'm_StyleSheet')
  i938.m_TextStyleHashCode = i939[35]
  i938.m_overrideHtmlColors = !!i939[36]
  i938.m_faceColor = UnityEngine.Color32.ConstructColor(i939[37], i939[38], i939[39], i939[40])
  i938.m_fontSize = i939[41]
  i938.m_fontSizeBase = i939[42]
  i938.m_fontWeight = i939[43]
  i938.m_enableAutoSizing = !!i939[44]
  i938.m_fontSizeMin = i939[45]
  i938.m_fontSizeMax = i939[46]
  i938.m_fontStyle = i939[47]
  i938.m_HorizontalAlignment = i939[48]
  i938.m_VerticalAlignment = i939[49]
  i938.m_textAlignment = i939[50]
  i938.m_characterSpacing = i939[51]
  i938.m_characterHorizontalScale = i939[52]
  i938.m_wordSpacing = i939[53]
  i938.m_lineSpacing = i939[54]
  i938.m_lineSpacingMax = i939[55]
  i938.m_paragraphSpacing = i939[56]
  i938.m_charWidthMaxAdj = i939[57]
  i938.m_TextWrappingMode = i939[58]
  i938.m_wordWrappingRatios = i939[59]
  i938.m_overflowMode = i939[60]
  request.r(i939[61], i939[62], 0, i938, 'm_linkedTextComponent')
  request.r(i939[63], i939[64], 0, i938, 'parentLinkedComponent')
  i938.m_enableKerning = !!i939[65]
  var i945 = i939[66]
  var i944 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.TextCore.OTL_FeatureTag')))
  for(var i = 0; i < i945.length; i += 1) {
    i944.add(i945[i + 0]);
  }
  i938.m_ActiveFontFeatures = i944
  i938.m_enableExtraPadding = !!i939[67]
  i938.checkPaddingRequired = !!i939[68]
  i938.m_isRichText = !!i939[69]
  i938.m_parseCtrlCharacters = !!i939[70]
  i938.m_isOrthographic = !!i939[71]
  i938.m_isCullingEnabled = !!i939[72]
  i938.m_horizontalMapping = i939[73]
  i938.m_verticalMapping = i939[74]
  i938.m_uvLineOffset = i939[75]
  i938.m_geometrySortingOrder = i939[76]
  i938.m_IsTextObjectScaleStatic = !!i939[77]
  i938.m_VertexBufferAutoSizeReduction = !!i939[78]
  i938.m_useMaxVisibleDescender = !!i939[79]
  i938.m_pageToDisplay = i939[80]
  i938.m_margin = new pc.Vec4( i939[81], i939[82], i939[83], i939[84] )
  i938.m_isUsingLegacyAnimationComponent = !!i939[85]
  i938.m_isVolumetricText = !!i939[86]
  request.r(i939[87], i939[88], 0, i938, 'm_Material')
  i938.m_EmojiFallbackSupport = !!i939[89]
  i938.m_Maskable = !!i939[90]
  i938.m_Color = new pc.Color(i939[91], i939[92], i939[93], i939[94])
  i938.m_RaycastTarget = !!i939[95]
  i938.m_RaycastPadding = new pc.Vec4( i939[96], i939[97], i939[98], i939[99] )
  return i938
}

Deserializers["TMPro.VertexGradient"] = function (request, data, root) {
  var i946 = root || request.c( 'TMPro.VertexGradient' )
  var i947 = data
  i946.topLeft = new pc.Color(i947[0], i947[1], i947[2], i947[3])
  i946.topRight = new pc.Color(i947[4], i947[5], i947[6], i947[7])
  i946.bottomLeft = new pc.Color(i947[8], i947[9], i947[10], i947[11])
  i946.bottomRight = new pc.Color(i947[12], i947[13], i947[14], i947[15])
  return i946
}

Deserializers["TutorialHandPointer"] = function (request, data, root) {
  var i950 = root || request.c( 'TutorialHandPointer' )
  var i951 = data
  request.r(i951[0], i951[1], 0, i950, 'm_spriteHand')
  i950.m_startedColor = new pc.Color(i951[2], i951[3], i951[4], i951[5])
  i950.m_alphaColor = new pc.Color(i951[6], i951[7], i951[8], i951[9])
  return i950
}

Deserializers["DinoCarousel"] = function (request, data, root) {
  var i952 = root || request.c( 'DinoCarousel' )
  var i953 = data
  var i955 = i953[0]
  var i954 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.UI.Image')))
  for(var i = 0; i < i955.length; i += 2) {
  request.r(i955[i + 0], i955[i + 1], 1, i954, '')
  }
  i952.m_entitiesSprites = i954
  i952.m_animationDuration = i953[1]
  i952.m_slideDistance = i953[2]
  i952.m_easeType = i953[3]
  i952.m_startedSpritePosition = new pc.Vec2( i953[4], i953[5] )
  i952.m_startedColor = new pc.Color(i953[6], i953[7], i953[8], i953[9])
  request.r(i953[10], i953[11], 0, i952, 'm_frameImage')
  request.r(i953[12], i953[13], 0, i952, 'm_mirrorImage')
  request.r(i953[14], i953[15], 0, i952, 'm_gameObjectLeftArrow')
  request.r(i953[16], i953[17], 0, i952, 'm_gameObjectRightArrow')
  return i952
}

Deserializers["PlayNowButton"] = function (request, data, root) {
  var i958 = root || request.c( 'PlayNowButton' )
  var i959 = data
  i958.m_scaleUpFactor = i959[0]
  i958.m_scaleDuration = i959[1]
  i958.m_easeType = i959[2]
  request.r(i959[3], i959[4], 0, i958, 'm_goToStoreButton')
  return i958
}

Deserializers["UnityEngine.UI.AspectRatioFitter"] = function (request, data, root) {
  var i960 = root || request.c( 'UnityEngine.UI.AspectRatioFitter' )
  var i961 = data
  i960.m_AspectMode = i961[0]
  i960.m_AspectRatio = i961[1]
  return i960
}

Deserializers["TutorialHand"] = function (request, data, root) {
  var i962 = root || request.c( 'TutorialHand' )
  var i963 = data
  request.r(i963[0], i963[1], 0, i962, 'm_spriteRenderer')
  request.r(i963[2], i963[3], 0, i962, 'm_objectManager')
  i962.m_firstHintDelay = i963[4]
  i962.m_playerInactivityForTutorial = i963[5]
  i962.m_escalatedInactivity = i963[6]
  i962.m_dragDuration = i963[7]
  i962.m_screenMargin = i963[8]
  return i962
}

Deserializers["FogManager"] = function (request, data, root) {
  var i964 = root || request.c( 'FogManager' )
  var i965 = data
  request.r(i965[0], i965[1], 0, i964, 'm_fogObjectPrefab')
  var i967 = i965[2]
  var i966 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.Vector2Int')))
  for(var i = 0; i < i967.length; i += 2) {
    i966.add(new pc.Vec2( i967[i + 0], i967[i + 1] ));
  }
  i964.m_revealFogCoordinatesStep1 = i966
  var i969 = i965[3]
  var i968 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.Vector2Int')))
  for(var i = 0; i < i969.length; i += 2) {
    i968.add(new pc.Vec2( i969[i + 0], i969[i + 1] ));
  }
  i964.m_revealFogCoordinatesStep2 = i968
  return i964
}

Deserializers["MapFogLayoutManager"] = function (request, data, root) {
  var i972 = root || request.c( 'MapFogLayoutManager' )
  var i973 = data
  i972.m_mapLayout = request.d('MapFogLayoutManager+MapFogLayout', i973[0], i972.m_mapLayout)
  return i972
}

Deserializers["MapFogLayoutManager+MapFogLayout"] = function (request, data, root) {
  var i974 = root || request.c( 'MapFogLayoutManager+MapFogLayout' )
  var i975 = data
  var i977 = i975[0]
  var i976 = new (System.Collections.Generic.List$1(Bridge.ns('MapFogLayoutManager+CellFogData')))
  for(var i = 0; i < i977.length; i += 1) {
    i976.add(request.d('MapFogLayoutManager+CellFogData', i977[i + 0]));
  }
  i974.m_cellData = i976
  return i974
}

Deserializers["MapFogLayoutManager+CellFogData"] = function (request, data, root) {
  var i980 = root || request.c( 'MapFogLayoutManager+CellFogData' )
  var i981 = data
  i980.x = i981[0]
  i980.y = i981[1]
  return i980
}

Deserializers["ObjectManager"] = function (request, data, root) {
  var i982 = root || request.c( 'ObjectManager' )
  var i983 = data
  var i985 = i983[0]
  var i984 = new (System.Collections.Generic.List$1(Bridge.ns('DragObject')))
  for(var i = 0; i < i985.length; i += 2) {
  request.r(i985[i + 0], i985[i + 1], 1, i984, '')
  }
  i982.m_matchObjectPrefabs = i984
  var i987 = i983[1]
  var i986 = new (System.Collections.Generic.List$1(Bridge.ns('FlyableMergeObject')))
  for(var i = 0; i < i987.length; i += 2) {
  request.r(i987[i + 0], i987[i + 1], 1, i986, '')
  }
  i982.m_flyableObjectPrefabs = i986
  var i989 = i983[2]
  var i988 = new (System.Collections.Generic.List$1(Bridge.ns('DecorationObject')))
  for(var i = 0; i < i989.length; i += 2) {
  request.r(i989[i + 0], i989[i + 1], 1, i988, '')
  }
  i982.m_decorationObjects = i988
  request.r(i983[3], i983[4], 0, i982, 'm_pointsManager')
  request.r(i983[5], i983[6], 0, i982, 'm_tapTextTutorial')
  return i982
}

Deserializers["MapObjectLayoutManager"] = function (request, data, root) {
  var i996 = root || request.c( 'MapObjectLayoutManager' )
  var i997 = data
  i996.m_mapLayout = request.d('MapObjectLayoutManager+MapObjectLayout', i997[0], i996.m_mapLayout)
  return i996
}

Deserializers["MapObjectLayoutManager+MapObjectLayout"] = function (request, data, root) {
  var i998 = root || request.c( 'MapObjectLayoutManager+MapObjectLayout' )
  var i999 = data
  var i1001 = i999[0]
  var i1000 = new (System.Collections.Generic.List$1(Bridge.ns('MapObjectLayoutManager+CellObjectData')))
  for(var i = 0; i < i1001.length; i += 1) {
    i1000.add(request.d('MapObjectLayoutManager+CellObjectData', i1001[i + 0]));
  }
  i998.m_cellData = i1000
  return i998
}

Deserializers["MapObjectLayoutManager+CellObjectData"] = function (request, data, root) {
  var i1004 = root || request.c( 'MapObjectLayoutManager+CellObjectData' )
  var i1005 = data
  i1004.x = i1005[0]
  i1004.y = i1005[1]
  i1004.objectType = i1005[2]
  return i1004
}

Deserializers["MainSystem"] = function (request, data, root) {
  var i1006 = root || request.c( 'MainSystem' )
  var i1007 = data
  i1006.m_widthInCells = i1007[0]
  i1006.m_heightInCells = i1007[1]
  i1006.m_gridMode = i1007[2]
  request.r(i1007[3], i1007[4], 0, i1006, 'm_customShape')
  request.r(i1007[5], i1007[6], 0, i1006, 'm_lightPrefab')
  request.r(i1007[7], i1007[8], 0, i1006, 'm_darkPrefab')
  request.r(i1007[9], i1007[10], 0, i1006, 'm_fogManager')
  request.r(i1007[11], i1007[12], 0, i1006, 'm_mapObjectLayoutManager')
  request.r(i1007[13], i1007[14], 0, i1006, 'm_mapFogLayoutManager')
  request.r(i1007[15], i1007[16], 0, i1006, 'm_objectManager')
  request.r(i1007[17], i1007[18], 0, i1006, 'm_pointsManager')
  return i1006
}

Deserializers["FlyingObjectsManager"] = function (request, data, root) {
  var i1008 = root || request.c( 'FlyingObjectsManager' )
  var i1009 = data
  request.r(i1009[0], i1009[1], 0, i1008, 'm_flyingPrincess1LevelPrefab')
  i1008.flyingPrincess1LevelCount = i1009[2]
  request.r(i1009[3], i1009[4], 0, i1008, 'm_flyingPrincess2LevelPrefab')
  i1008.flyingPrincess2LevelCount = i1009[5]
  return i1008
}

Deserializers["PointsManager"] = function (request, data, root) {
  var i1010 = root || request.c( 'PointsManager' )
  var i1011 = data
  i1010.m_pointsCount = i1011[0]
  request.r(i1011[1], i1011[2], 0, i1010, 'm_flyingObjectManager')
  return i1010
}

Deserializers["DragManager"] = function (request, data, root) {
  var i1012 = root || request.c( 'DragManager' )
  var i1013 = data
  i1012.m_snapDistance = i1013[0]
  request.r(i1013[1], i1013[2], 0, i1012, 'm_highlightedZone')
  request.r(i1013[3], i1013[4], 0, i1012, 'm_pointsManager')
  request.r(i1013[5], i1013[6], 0, i1012, 'm_mergeEffectParticleSystem')
  request.r(i1013[7], i1013[8], 0, i1012, 'm_objectManager')
  request.r(i1013[9], i1013[10], 0, i1012, 'm_flyingObjectsManager')
  request.r(i1013[11], i1013[12], 0, i1012, 'm_fogManager')
  request.r(i1013[13], i1013[14], 0, i1012, 'm_mergeText')
  request.r(i1013[15], i1013[16], 0, i1012, 'm_dinoSelectionManager')
  return i1012
}

Deserializers["FlyingDragManager"] = function (request, data, root) {
  var i1014 = root || request.c( 'FlyingDragManager' )
  var i1015 = data
  i1014.m_snapDistance = i1015[0]
  i1014.mergeRadius = i1015[1]
  i1014.pullSpeed = i1015[2]
  request.r(i1015[3], i1015[4], 0, i1014, 'm_highlightedZone')
  request.r(i1015[5], i1015[6], 0, i1014, 'm_flyingObjectsManager')
  request.r(i1015[7], i1015[8], 0, i1014, 'm_mergeEffectParticleSystem')
  request.r(i1015[9], i1015[10], 0, i1014, 'm_pointsManager')
  return i1014
}

Deserializers["DinoSelectionManager"] = function (request, data, root) {
  var i1016 = root || request.c( 'DinoSelectionManager' )
  var i1017 = data
  request.r(i1017[0], i1017[1], 0, i1016, 'm_mainSystem')
  request.r(i1017[2], i1017[3], 0, i1016, 'm_cameraController')
  request.r(i1017[4], i1017[5], 0, i1016, 'm_choosingScreenOverlay')
  request.r(i1017[6], i1017[7], 0, i1016, 'm_dinoCarousel')
  request.r(i1017[8], i1017[9], 0, i1016, 'm_heartEffect')
  request.r(i1017[10], i1017[11], 0, i1016, 'm_chosenDinoPosition')
  request.r(i1017[12], i1017[13], 0, i1016, 'm_logoPlayNowButton')
  request.r(i1017[14], i1017[15], 0, i1016, 'm_logoPlayNowNewButtonPosition')
  request.r(i1017[16], i1017[17], 0, i1016, 'm_nextDinoButton')
  request.r(i1017[18], i1017[19], 0, i1016, 'm_previousDinoButton')
  request.r(i1017[20], i1017[21], 0, i1016, 'm_chooseDinoButton')
  request.r(i1017[22], i1017[23], 0, i1016, 'm_tutorialHandChooseButton')
  request.r(i1017[24], i1017[25], 0, i1016, 'm_arrowHandTutorial')
  request.r(i1017[26], i1017[27], 0, i1016, 'm_choosingScreenWorldCanvas')
  request.r(i1017[28], i1017[29], 0, i1016, 'm_mapObjectLayoutManager')
  var i1019 = i1017[30]
  var i1018 = new (System.Collections.Generic.List$1(Bridge.ns('ObjectSet')))
  for(var i = 0; i < i1019.length; i += 2) {
  request.r(i1019[i + 0], i1019[i + 1], 1, i1018, '')
  }
  i1016.m_dinoObjectSets = i1018
  request.r(i1017[31], i1017[32], 0, i1016, 'm_rewardCard')
  request.r(i1017[33], i1017[34], 0, i1016, 'm_rewardCardImage')
  request.r(i1017[35], i1017[36], 0, i1016, 'm_rewardCardButton')
  request.r(i1017[37], i1017[38], 0, i1016, 'm_carouselGroup')
  return i1016
}

Deserializers["AudioSystem"] = function (request, data, root) {
  var i1022 = root || request.c( 'AudioSystem' )
  var i1023 = data
  request.r(i1023[0], i1023[1], 0, i1022, 'musicAudioSource')
  request.r(i1023[2], i1023[3], 0, i1022, 'soundFXAudioSource1')
  request.r(i1023[4], i1023[5], 0, i1022, 'soundFXAudioSource2')
  request.r(i1023[6], i1023[7], 0, i1022, 'm_mergeSoundClip')
  request.r(i1023[8], i1023[9], 0, i1022, 'm_chooseClip')
  request.r(i1023[10], i1023[11], 0, i1022, 'm_fogDissolveClip')
  request.r(i1023[12], i1023[13], 0, i1022, 'm_bubbleClip')
  request.r(i1023[14], i1023[15], 0, i1022, 'm_starSoundClip')
  return i1022
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.AudioSource"] = function (request, data, root) {
  var i1024 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.AudioSource' )
  var i1025 = data
  request.r(i1025[0], i1025[1], 0, i1024, 'clip')
  request.r(i1025[2], i1025[3], 0, i1024, 'outputAudioMixerGroup')
  i1024.playOnAwake = !!i1025[4]
  i1024.loop = !!i1025[5]
  i1024.time = i1025[6]
  i1024.volume = i1025[7]
  i1024.pitch = i1025[8]
  i1024.enabled = !!i1025[9]
  return i1024
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.RenderSettings"] = function (request, data, root) {
  var i1026 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.RenderSettings' )
  var i1027 = data
  i1026.ambientIntensity = i1027[0]
  i1026.reflectionIntensity = i1027[1]
  i1026.ambientMode = i1027[2]
  i1026.ambientLight = new pc.Color(i1027[3], i1027[4], i1027[5], i1027[6])
  i1026.ambientSkyColor = new pc.Color(i1027[7], i1027[8], i1027[9], i1027[10])
  i1026.ambientGroundColor = new pc.Color(i1027[11], i1027[12], i1027[13], i1027[14])
  i1026.ambientEquatorColor = new pc.Color(i1027[15], i1027[16], i1027[17], i1027[18])
  i1026.fogColor = new pc.Color(i1027[19], i1027[20], i1027[21], i1027[22])
  i1026.fogEndDistance = i1027[23]
  i1026.fogStartDistance = i1027[24]
  i1026.fogDensity = i1027[25]
  i1026.fog = !!i1027[26]
  request.r(i1027[27], i1027[28], 0, i1026, 'skybox')
  i1026.fogMode = i1027[29]
  var i1029 = i1027[30]
  var i1028 = []
  for(var i = 0; i < i1029.length; i += 1) {
    i1028.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+Lightmap', i1029[i + 0]) );
  }
  i1026.lightmaps = i1028
  i1026.lightProbes = request.d('Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+LightProbes', i1027[31], i1026.lightProbes)
  i1026.lightmapsMode = i1027[32]
  i1026.mixedBakeMode = i1027[33]
  i1026.environmentLightingMode = i1027[34]
  i1026.ambientProbe = new pc.SphericalHarmonicsL2(i1027[35])
  request.r(i1027[36], i1027[37], 0, i1026, 'customReflection')
  request.r(i1027[38], i1027[39], 0, i1026, 'defaultReflection')
  i1026.defaultReflectionMode = i1027[40]
  i1026.defaultReflectionResolution = i1027[41]
  i1026.sunLightObjectId = i1027[42]
  i1026.pixelLightCount = i1027[43]
  i1026.defaultReflectionHDR = !!i1027[44]
  i1026.hasLightDataAsset = !!i1027[45]
  i1026.hasManualGenerate = !!i1027[46]
  return i1026
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+Lightmap"] = function (request, data, root) {
  var i1032 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+Lightmap' )
  var i1033 = data
  request.r(i1033[0], i1033[1], 0, i1032, 'lightmapColor')
  request.r(i1033[2], i1033[3], 0, i1032, 'lightmapDirection')
  request.r(i1033[4], i1033[5], 0, i1032, 'shadowMask')
  return i1032
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+LightProbes"] = function (request, data, root) {
  var i1034 = root || new UnityEngine.LightProbes()
  var i1035 = data
  return i1034
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerCanvas"] = function (request, data, root) {
  var i1042 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerCanvas' )
  var i1043 = data
  request.r(i1043[0], i1043[1], 0, i1042, 'panelPrefab')
  var i1045 = i1043[2]
  var i1044 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.Rendering.UI.DebugUIPrefabBundle')))
  for(var i = 0; i < i1045.length; i += 1) {
    i1044.add(request.d('UnityEngine.Rendering.UI.DebugUIPrefabBundle', i1045[i + 0]));
  }
  i1042.prefabs = i1044
  return i1042
}

Deserializers["UnityEngine.Rendering.UI.DebugUIPrefabBundle"] = function (request, data, root) {
  var i1048 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIPrefabBundle' )
  var i1049 = data
  i1048.type = i1049[0]
  request.r(i1049[1], i1049[2], 0, i1048, 'prefab')
  return i1048
}

Deserializers["UnityEngine.UI.VerticalLayoutGroup"] = function (request, data, root) {
  var i1050 = root || request.c( 'UnityEngine.UI.VerticalLayoutGroup' )
  var i1051 = data
  i1050.m_Spacing = i1051[0]
  i1050.m_ChildForceExpandWidth = !!i1051[1]
  i1050.m_ChildForceExpandHeight = !!i1051[2]
  i1050.m_ChildControlWidth = !!i1051[3]
  i1050.m_ChildControlHeight = !!i1051[4]
  i1050.m_ChildScaleWidth = !!i1051[5]
  i1050.m_ChildScaleHeight = !!i1051[6]
  i1050.m_ReverseArrangement = !!i1051[7]
  i1050.m_Padding = UnityEngine.RectOffset.FromPaddings(i1051[8], i1051[9], i1051[10], i1051[11])
  i1050.m_ChildAlignment = i1051[12]
  return i1050
}

Deserializers["UnityEngine.UI.ContentSizeFitter"] = function (request, data, root) {
  var i1052 = root || request.c( 'UnityEngine.UI.ContentSizeFitter' )
  var i1053 = data
  i1052.m_HorizontalFit = i1053[0]
  i1052.m_VerticalFit = i1053[1]
  return i1052
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerContainer"] = function (request, data, root) {
  var i1054 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerContainer' )
  var i1055 = data
  request.r(i1055[0], i1055[1], 0, i1054, 'contentHolder')
  return i1054
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerPanel"] = function (request, data, root) {
  var i1056 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerPanel' )
  var i1057 = data
  request.r(i1057[0], i1057[1], 0, i1056, 'nameLabel')
  request.r(i1057[2], i1057[3], 0, i1056, 'scrollRect')
  request.r(i1057[4], i1057[5], 0, i1056, 'viewport')
  request.r(i1057[6], i1057[7], 0, i1056, 'Canvas')
  return i1056
}

Deserializers["UnityEngine.UI.LayoutElement"] = function (request, data, root) {
  var i1058 = root || request.c( 'UnityEngine.UI.LayoutElement' )
  var i1059 = data
  i1058.m_IgnoreLayout = !!i1059[0]
  i1058.m_MinWidth = i1059[1]
  i1058.m_MinHeight = i1059[2]
  i1058.m_PreferredWidth = i1059[3]
  i1058.m_PreferredHeight = i1059[4]
  i1058.m_FlexibleWidth = i1059[5]
  i1058.m_FlexibleHeight = i1059[6]
  i1058.m_LayoutPriority = i1059[7]
  return i1058
}

Deserializers["UnityEngine.Events.ArgumentCache"] = function (request, data, root) {
  var i1060 = root || request.c( 'UnityEngine.Events.ArgumentCache' )
  var i1061 = data
  request.r(i1061[0], i1061[1], 0, i1060, 'm_ObjectArgument')
  i1060.m_ObjectArgumentAssemblyTypeName = i1061[2]
  i1060.m_IntArgument = i1061[3]
  i1060.m_FloatArgument = i1061[4]
  i1060.m_StringArgument = i1061[5]
  i1060.m_BoolArgument = !!i1061[6]
  return i1060
}

Deserializers["UnityEngine.UI.Text"] = function (request, data, root) {
  var i1062 = root || request.c( 'UnityEngine.UI.Text' )
  var i1063 = data
  i1062.m_FontData = request.d('UnityEngine.UI.FontData', i1063[0], i1062.m_FontData)
  i1062.m_Text = i1063[1]
  request.r(i1063[2], i1063[3], 0, i1062, 'm_Material')
  i1062.m_Maskable = !!i1063[4]
  i1062.m_Color = new pc.Color(i1063[5], i1063[6], i1063[7], i1063[8])
  i1062.m_RaycastTarget = !!i1063[9]
  i1062.m_RaycastPadding = new pc.Vec4( i1063[10], i1063[11], i1063[12], i1063[13] )
  return i1062
}

Deserializers["UnityEngine.UI.FontData"] = function (request, data, root) {
  var i1064 = root || request.c( 'UnityEngine.UI.FontData' )
  var i1065 = data
  request.r(i1065[0], i1065[1], 0, i1064, 'm_Font')
  i1064.m_FontSize = i1065[2]
  i1064.m_FontStyle = i1065[3]
  i1064.m_BestFit = !!i1065[4]
  i1064.m_MinSize = i1065[5]
  i1064.m_MaxSize = i1065[6]
  i1064.m_Alignment = i1065[7]
  i1064.m_AlignByGeometry = !!i1065[8]
  i1064.m_RichText = !!i1065[9]
  i1064.m_HorizontalOverflow = i1065[10]
  i1064.m_VerticalOverflow = i1065[11]
  i1064.m_LineSpacing = i1065[12]
  return i1064
}

Deserializers["UnityEngine.UI.ScrollRect"] = function (request, data, root) {
  var i1066 = root || request.c( 'UnityEngine.UI.ScrollRect' )
  var i1067 = data
  request.r(i1067[0], i1067[1], 0, i1066, 'm_Content')
  i1066.m_Horizontal = !!i1067[2]
  i1066.m_Vertical = !!i1067[3]
  i1066.m_MovementType = i1067[4]
  i1066.m_Elasticity = i1067[5]
  i1066.m_Inertia = !!i1067[6]
  i1066.m_DecelerationRate = i1067[7]
  i1066.m_ScrollSensitivity = i1067[8]
  request.r(i1067[9], i1067[10], 0, i1066, 'm_Viewport')
  request.r(i1067[11], i1067[12], 0, i1066, 'm_HorizontalScrollbar')
  request.r(i1067[13], i1067[14], 0, i1066, 'm_VerticalScrollbar')
  i1066.m_HorizontalScrollbarVisibility = i1067[15]
  i1066.m_VerticalScrollbarVisibility = i1067[16]
  i1066.m_HorizontalScrollbarSpacing = i1067[17]
  i1066.m_VerticalScrollbarSpacing = i1067[18]
  i1066.m_OnValueChanged = request.d('UnityEngine.UI.ScrollRect+ScrollRectEvent', i1067[19], i1066.m_OnValueChanged)
  return i1066
}

Deserializers["UnityEngine.UI.ScrollRect+ScrollRectEvent"] = function (request, data, root) {
  var i1068 = root || request.c( 'UnityEngine.UI.ScrollRect+ScrollRectEvent' )
  var i1069 = data
  i1068.m_PersistentCalls = request.d('UnityEngine.Events.PersistentCallGroup', i1069[0], i1068.m_PersistentCalls)
  return i1068
}

Deserializers["UnityEngine.UI.Mask"] = function (request, data, root) {
  var i1070 = root || request.c( 'UnityEngine.UI.Mask' )
  var i1071 = data
  i1070.m_ShowMaskGraphic = !!i1071[0]
  return i1070
}

Deserializers["UnityEngine.UI.Scrollbar"] = function (request, data, root) {
  var i1072 = root || request.c( 'UnityEngine.UI.Scrollbar' )
  var i1073 = data
  request.r(i1073[0], i1073[1], 0, i1072, 'm_HandleRect')
  i1072.m_Direction = i1073[2]
  i1072.m_Value = i1073[3]
  i1072.m_Size = i1073[4]
  i1072.m_NumberOfSteps = i1073[5]
  i1072.m_OnValueChanged = request.d('UnityEngine.UI.Scrollbar+ScrollEvent', i1073[6], i1072.m_OnValueChanged)
  i1072.m_Navigation = request.d('UnityEngine.UI.Navigation', i1073[7], i1072.m_Navigation)
  i1072.m_Transition = i1073[8]
  i1072.m_Colors = request.d('UnityEngine.UI.ColorBlock', i1073[9], i1072.m_Colors)
  i1072.m_SpriteState = request.d('UnityEngine.UI.SpriteState', i1073[10], i1072.m_SpriteState)
  i1072.m_AnimationTriggers = request.d('UnityEngine.UI.AnimationTriggers', i1073[11], i1072.m_AnimationTriggers)
  i1072.m_Interactable = !!i1073[12]
  request.r(i1073[13], i1073[14], 0, i1072, 'm_TargetGraphic')
  return i1072
}

Deserializers["UnityEngine.UI.Scrollbar+ScrollEvent"] = function (request, data, root) {
  var i1074 = root || request.c( 'UnityEngine.UI.Scrollbar+ScrollEvent' )
  var i1075 = data
  i1074.m_PersistentCalls = request.d('UnityEngine.Events.PersistentCallGroup', i1075[0], i1074.m_PersistentCalls)
  return i1074
}

Deserializers["UnityEngine.EventSystems.EventTrigger"] = function (request, data, root) {
  var i1076 = root || request.c( 'UnityEngine.EventSystems.EventTrigger' )
  var i1077 = data
  var i1079 = i1077[0]
  var i1078 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.EventSystems.EventTrigger+Entry')))
  for(var i = 0; i < i1079.length; i += 1) {
    i1078.add(request.d('UnityEngine.EventSystems.EventTrigger+Entry', i1079[i + 0]));
  }
  i1076.m_Delegates = i1078
  return i1076
}

Deserializers["UnityEngine.EventSystems.EventTrigger+Entry"] = function (request, data, root) {
  var i1082 = root || request.c( 'UnityEngine.EventSystems.EventTrigger+Entry' )
  var i1083 = data
  i1082.eventID = i1083[0]
  i1082.callback = request.d('UnityEngine.EventSystems.EventTrigger+TriggerEvent', i1083[1], i1082.callback)
  return i1082
}

Deserializers["UnityEngine.EventSystems.EventTrigger+TriggerEvent"] = function (request, data, root) {
  var i1084 = root || request.c( 'UnityEngine.EventSystems.EventTrigger+TriggerEvent' )
  var i1085 = data
  i1084.m_PersistentCalls = request.d('UnityEngine.Events.PersistentCallGroup', i1085[0], i1084.m_PersistentCalls)
  return i1084
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerValue"] = function (request, data, root) {
  var i1086 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerValue' )
  var i1087 = data
  request.r(i1087[0], i1087[1], 0, i1086, 'nameLabel')
  request.r(i1087[2], i1087[3], 0, i1086, 'valueLabel')
  i1086.colorDefault = new pc.Color(i1087[4], i1087[5], i1087[6], i1087[7])
  i1086.colorSelected = new pc.Color(i1087[8], i1087[9], i1087[10], i1087[11])
  return i1086
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerToggle"] = function (request, data, root) {
  var i1088 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerToggle' )
  var i1089 = data
  request.r(i1089[0], i1089[1], 0, i1088, 'nameLabel')
  request.r(i1089[2], i1089[3], 0, i1088, 'valueToggle')
  request.r(i1089[4], i1089[5], 0, i1088, 'checkmarkImage')
  i1088.colorDefault = new pc.Color(i1089[6], i1089[7], i1089[8], i1089[9])
  i1088.colorSelected = new pc.Color(i1089[10], i1089[11], i1089[12], i1089[13])
  return i1088
}

Deserializers["UnityEngine.UI.Toggle"] = function (request, data, root) {
  var i1090 = root || request.c( 'UnityEngine.UI.Toggle' )
  var i1091 = data
  i1090.toggleTransition = i1091[0]
  request.r(i1091[1], i1091[2], 0, i1090, 'graphic')
  i1090.onValueChanged = request.d('UnityEngine.UI.Toggle+ToggleEvent', i1091[3], i1090.onValueChanged)
  request.r(i1091[4], i1091[5], 0, i1090, 'm_Group')
  i1090.m_IsOn = !!i1091[6]
  i1090.m_Navigation = request.d('UnityEngine.UI.Navigation', i1091[7], i1090.m_Navigation)
  i1090.m_Transition = i1091[8]
  i1090.m_Colors = request.d('UnityEngine.UI.ColorBlock', i1091[9], i1090.m_Colors)
  i1090.m_SpriteState = request.d('UnityEngine.UI.SpriteState', i1091[10], i1090.m_SpriteState)
  i1090.m_AnimationTriggers = request.d('UnityEngine.UI.AnimationTriggers', i1091[11], i1090.m_AnimationTriggers)
  i1090.m_Interactable = !!i1091[12]
  request.r(i1091[13], i1091[14], 0, i1090, 'm_TargetGraphic')
  return i1090
}

Deserializers["UnityEngine.UI.Toggle+ToggleEvent"] = function (request, data, root) {
  var i1092 = root || request.c( 'UnityEngine.UI.Toggle+ToggleEvent' )
  var i1093 = data
  i1092.m_PersistentCalls = request.d('UnityEngine.Events.PersistentCallGroup', i1093[0], i1092.m_PersistentCalls)
  return i1092
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerIntField"] = function (request, data, root) {
  var i1094 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerIntField' )
  var i1095 = data
  request.r(i1095[0], i1095[1], 0, i1094, 'nameLabel')
  request.r(i1095[2], i1095[3], 0, i1094, 'valueLabel')
  i1094.colorDefault = new pc.Color(i1095[4], i1095[5], i1095[6], i1095[7])
  i1094.colorSelected = new pc.Color(i1095[8], i1095[9], i1095[10], i1095[11])
  return i1094
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerUIntField"] = function (request, data, root) {
  var i1096 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerUIntField' )
  var i1097 = data
  request.r(i1097[0], i1097[1], 0, i1096, 'nameLabel')
  request.r(i1097[2], i1097[3], 0, i1096, 'valueLabel')
  i1096.colorDefault = new pc.Color(i1097[4], i1097[5], i1097[6], i1097[7])
  i1096.colorSelected = new pc.Color(i1097[8], i1097[9], i1097[10], i1097[11])
  return i1096
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerFloatField"] = function (request, data, root) {
  var i1098 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerFloatField' )
  var i1099 = data
  request.r(i1099[0], i1099[1], 0, i1098, 'nameLabel')
  request.r(i1099[2], i1099[3], 0, i1098, 'valueLabel')
  i1098.colorDefault = new pc.Color(i1099[4], i1099[5], i1099[6], i1099[7])
  i1098.colorSelected = new pc.Color(i1099[8], i1099[9], i1099[10], i1099[11])
  return i1098
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerEnumField"] = function (request, data, root) {
  var i1100 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerEnumField' )
  var i1101 = data
  request.r(i1101[0], i1101[1], 0, i1100, 'nextButtonText')
  request.r(i1101[2], i1101[3], 0, i1100, 'previousButtonText')
  request.r(i1101[4], i1101[5], 0, i1100, 'nameLabel')
  request.r(i1101[6], i1101[7], 0, i1100, 'valueLabel')
  i1100.colorDefault = new pc.Color(i1101[8], i1101[9], i1101[10], i1101[11])
  i1100.colorSelected = new pc.Color(i1101[12], i1101[13], i1101[14], i1101[15])
  return i1100
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerButton"] = function (request, data, root) {
  var i1102 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerButton' )
  var i1103 = data
  request.r(i1103[0], i1103[1], 0, i1102, 'nameLabel')
  i1102.colorDefault = new pc.Color(i1103[2], i1103[3], i1103[4], i1103[5])
  i1102.colorSelected = new pc.Color(i1103[6], i1103[7], i1103[8], i1103[9])
  return i1102
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerFoldout"] = function (request, data, root) {
  var i1104 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerFoldout' )
  var i1105 = data
  request.r(i1105[0], i1105[1], 0, i1104, 'nameLabel')
  request.r(i1105[2], i1105[3], 0, i1104, 'valueToggle')
  i1104.colorDefault = new pc.Color(i1105[4], i1105[5], i1105[6], i1105[7])
  i1104.colorSelected = new pc.Color(i1105[8], i1105[9], i1105[10], i1105[11])
  return i1104
}

Deserializers["UnityEngine.Rendering.UI.UIFoldout"] = function (request, data, root) {
  var i1106 = root || request.c( 'UnityEngine.Rendering.UI.UIFoldout' )
  var i1107 = data
  request.r(i1107[0], i1107[1], 0, i1106, 'content')
  request.r(i1107[2], i1107[3], 0, i1106, 'arrowOpened')
  request.r(i1107[4], i1107[5], 0, i1106, 'arrowClosed')
  i1106.toggleTransition = i1107[6]
  request.r(i1107[7], i1107[8], 0, i1106, 'graphic')
  i1106.onValueChanged = request.d('UnityEngine.UI.Toggle+ToggleEvent', i1107[9], i1106.onValueChanged)
  request.r(i1107[10], i1107[11], 0, i1106, 'm_Group')
  i1106.m_IsOn = !!i1107[12]
  i1106.m_Navigation = request.d('UnityEngine.UI.Navigation', i1107[13], i1106.m_Navigation)
  i1106.m_Transition = i1107[14]
  i1106.m_Colors = request.d('UnityEngine.UI.ColorBlock', i1107[15], i1106.m_Colors)
  i1106.m_SpriteState = request.d('UnityEngine.UI.SpriteState', i1107[16], i1106.m_SpriteState)
  i1106.m_AnimationTriggers = request.d('UnityEngine.UI.AnimationTriggers', i1107[17], i1106.m_AnimationTriggers)
  i1106.m_Interactable = !!i1107[18]
  request.r(i1107[19], i1107[20], 0, i1106, 'm_TargetGraphic')
  return i1106
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerColor"] = function (request, data, root) {
  var i1108 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerColor' )
  var i1109 = data
  request.r(i1109[0], i1109[1], 0, i1108, 'nameLabel')
  request.r(i1109[2], i1109[3], 0, i1108, 'valueToggle')
  request.r(i1109[4], i1109[5], 0, i1108, 'colorImage')
  request.r(i1109[6], i1109[7], 0, i1108, 'fieldR')
  request.r(i1109[8], i1109[9], 0, i1108, 'fieldG')
  request.r(i1109[10], i1109[11], 0, i1108, 'fieldB')
  request.r(i1109[12], i1109[13], 0, i1108, 'fieldA')
  i1108.colorDefault = new pc.Color(i1109[14], i1109[15], i1109[16], i1109[17])
  i1108.colorSelected = new pc.Color(i1109[18], i1109[19], i1109[20], i1109[21])
  return i1108
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerIndirectFloatField"] = function (request, data, root) {
  var i1110 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerIndirectFloatField' )
  var i1111 = data
  request.r(i1111[0], i1111[1], 0, i1110, 'nameLabel')
  request.r(i1111[2], i1111[3], 0, i1110, 'valueLabel')
  i1110.colorDefault = new pc.Color(i1111[4], i1111[5], i1111[6], i1111[7])
  i1110.colorSelected = new pc.Color(i1111[8], i1111[9], i1111[10], i1111[11])
  return i1110
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerVector2"] = function (request, data, root) {
  var i1112 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerVector2' )
  var i1113 = data
  request.r(i1113[0], i1113[1], 0, i1112, 'nameLabel')
  request.r(i1113[2], i1113[3], 0, i1112, 'valueToggle')
  request.r(i1113[4], i1113[5], 0, i1112, 'fieldX')
  request.r(i1113[6], i1113[7], 0, i1112, 'fieldY')
  i1112.colorDefault = new pc.Color(i1113[8], i1113[9], i1113[10], i1113[11])
  i1112.colorSelected = new pc.Color(i1113[12], i1113[13], i1113[14], i1113[15])
  return i1112
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerVector3"] = function (request, data, root) {
  var i1114 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerVector3' )
  var i1115 = data
  request.r(i1115[0], i1115[1], 0, i1114, 'nameLabel')
  request.r(i1115[2], i1115[3], 0, i1114, 'valueToggle')
  request.r(i1115[4], i1115[5], 0, i1114, 'fieldX')
  request.r(i1115[6], i1115[7], 0, i1114, 'fieldY')
  request.r(i1115[8], i1115[9], 0, i1114, 'fieldZ')
  i1114.colorDefault = new pc.Color(i1115[10], i1115[11], i1115[12], i1115[13])
  i1114.colorSelected = new pc.Color(i1115[14], i1115[15], i1115[16], i1115[17])
  return i1114
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerVector4"] = function (request, data, root) {
  var i1116 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerVector4' )
  var i1117 = data
  request.r(i1117[0], i1117[1], 0, i1116, 'nameLabel')
  request.r(i1117[2], i1117[3], 0, i1116, 'valueToggle')
  request.r(i1117[4], i1117[5], 0, i1116, 'fieldX')
  request.r(i1117[6], i1117[7], 0, i1116, 'fieldY')
  request.r(i1117[8], i1117[9], 0, i1116, 'fieldZ')
  request.r(i1117[10], i1117[11], 0, i1116, 'fieldW')
  i1116.colorDefault = new pc.Color(i1117[12], i1117[13], i1117[14], i1117[15])
  i1116.colorSelected = new pc.Color(i1117[16], i1117[17], i1117[18], i1117[19])
  return i1116
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerVBox"] = function (request, data, root) {
  var i1118 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerVBox' )
  var i1119 = data
  i1118.colorDefault = new pc.Color(i1119[0], i1119[1], i1119[2], i1119[3])
  i1118.colorSelected = new pc.Color(i1119[4], i1119[5], i1119[6], i1119[7])
  return i1118
}

Deserializers["UnityEngine.UI.HorizontalLayoutGroup"] = function (request, data, root) {
  var i1120 = root || request.c( 'UnityEngine.UI.HorizontalLayoutGroup' )
  var i1121 = data
  i1120.m_Spacing = i1121[0]
  i1120.m_ChildForceExpandWidth = !!i1121[1]
  i1120.m_ChildForceExpandHeight = !!i1121[2]
  i1120.m_ChildControlWidth = !!i1121[3]
  i1120.m_ChildControlHeight = !!i1121[4]
  i1120.m_ChildScaleWidth = !!i1121[5]
  i1120.m_ChildScaleHeight = !!i1121[6]
  i1120.m_ReverseArrangement = !!i1121[7]
  i1120.m_Padding = UnityEngine.RectOffset.FromPaddings(i1121[8], i1121[9], i1121[10], i1121[11])
  i1120.m_ChildAlignment = i1121[12]
  return i1120
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerHBox"] = function (request, data, root) {
  var i1122 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerHBox' )
  var i1123 = data
  i1122.colorDefault = new pc.Color(i1123[0], i1123[1], i1123[2], i1123[3])
  i1122.colorSelected = new pc.Color(i1123[4], i1123[5], i1123[6], i1123[7])
  return i1122
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerGroup"] = function (request, data, root) {
  var i1124 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerGroup' )
  var i1125 = data
  request.r(i1125[0], i1125[1], 0, i1124, 'nameLabel')
  request.r(i1125[2], i1125[3], 0, i1124, 'header')
  i1124.colorDefault = new pc.Color(i1125[4], i1125[5], i1125[6], i1125[7])
  i1124.colorSelected = new pc.Color(i1125[8], i1125[9], i1125[10], i1125[11])
  return i1124
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerBitField"] = function (request, data, root) {
  var i1126 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerBitField' )
  var i1127 = data
  request.r(i1127[0], i1127[1], 0, i1126, 'nameLabel')
  request.r(i1127[2], i1127[3], 0, i1126, 'valueToggle')
  var i1129 = i1127[4]
  var i1128 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.Rendering.UI.DebugUIHandlerIndirectToggle')))
  for(var i = 0; i < i1129.length; i += 2) {
  request.r(i1129[i + 0], i1129[i + 1], 1, i1128, '')
  }
  i1126.toggles = i1128
  i1126.colorDefault = new pc.Color(i1127[5], i1127[6], i1127[7], i1127[8])
  i1126.colorSelected = new pc.Color(i1127[9], i1127[10], i1127[11], i1127[12])
  return i1126
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerIndirectToggle"] = function (request, data, root) {
  var i1132 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerIndirectToggle' )
  var i1133 = data
  request.r(i1133[0], i1133[1], 0, i1132, 'nameLabel')
  request.r(i1133[2], i1133[3], 0, i1132, 'valueToggle')
  request.r(i1133[4], i1133[5], 0, i1132, 'checkmarkImage')
  i1132.colorDefault = new pc.Color(i1133[6], i1133[7], i1133[8], i1133[9])
  i1132.colorSelected = new pc.Color(i1133[10], i1133[11], i1133[12], i1133[13])
  return i1132
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerToggleHistory"] = function (request, data, root) {
  var i1134 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerToggleHistory' )
  var i1135 = data
  request.r(i1135[0], i1135[1], 0, i1134, 'nameLabel')
  request.r(i1135[2], i1135[3], 0, i1134, 'valueToggle')
  request.r(i1135[4], i1135[5], 0, i1134, 'checkmarkImage')
  i1134.colorDefault = new pc.Color(i1135[6], i1135[7], i1135[8], i1135[9])
  i1134.colorSelected = new pc.Color(i1135[10], i1135[11], i1135[12], i1135[13])
  return i1134
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerEnumHistory"] = function (request, data, root) {
  var i1136 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerEnumHistory' )
  var i1137 = data
  request.r(i1137[0], i1137[1], 0, i1136, 'nextButtonText')
  request.r(i1137[2], i1137[3], 0, i1136, 'previousButtonText')
  request.r(i1137[4], i1137[5], 0, i1136, 'nameLabel')
  request.r(i1137[6], i1137[7], 0, i1136, 'valueLabel')
  i1136.colorDefault = new pc.Color(i1137[8], i1137[9], i1137[10], i1137[11])
  i1136.colorSelected = new pc.Color(i1137[12], i1137[13], i1137[14], i1137[15])
  return i1136
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerRow"] = function (request, data, root) {
  var i1138 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerRow' )
  var i1139 = data
  request.r(i1139[0], i1139[1], 0, i1138, 'nameLabel')
  request.r(i1139[2], i1139[3], 0, i1138, 'valueToggle')
  i1138.colorDefault = new pc.Color(i1139[4], i1139[5], i1139[6], i1139[7])
  i1138.colorSelected = new pc.Color(i1139[8], i1139[9], i1139[10], i1139[11])
  return i1138
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerMessageBox"] = function (request, data, root) {
  var i1140 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerMessageBox' )
  var i1141 = data
  request.r(i1141[0], i1141[1], 0, i1140, 'nameLabel')
  i1140.colorDefault = new pc.Color(i1141[2], i1141[3], i1141[4], i1141[5])
  i1140.colorSelected = new pc.Color(i1141[6], i1141[7], i1141[8], i1141[9])
  return i1140
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerProgressBar"] = function (request, data, root) {
  var i1142 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerProgressBar' )
  var i1143 = data
  request.r(i1143[0], i1143[1], 0, i1142, 'nameLabel')
  request.r(i1143[2], i1143[3], 0, i1142, 'valueLabel')
  request.r(i1143[4], i1143[5], 0, i1142, 'progressBarRect')
  i1142.colorDefault = new pc.Color(i1143[6], i1143[7], i1143[8], i1143[9])
  i1142.colorSelected = new pc.Color(i1143[10], i1143[11], i1143[12], i1143[13])
  return i1142
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerValueTuple"] = function (request, data, root) {
  var i1144 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerValueTuple' )
  var i1145 = data
  request.r(i1145[0], i1145[1], 0, i1144, 'nameLabel')
  request.r(i1145[2], i1145[3], 0, i1144, 'valueLabel')
  i1144.colorDefault = new pc.Color(i1145[4], i1145[5], i1145[6], i1145[7])
  i1144.colorSelected = new pc.Color(i1145[8], i1145[9], i1145[10], i1145[11])
  return i1144
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerObject"] = function (request, data, root) {
  var i1146 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerObject' )
  var i1147 = data
  request.r(i1147[0], i1147[1], 0, i1146, 'nameLabel')
  request.r(i1147[2], i1147[3], 0, i1146, 'valueLabel')
  i1146.colorDefault = new pc.Color(i1147[4], i1147[5], i1147[6], i1147[7])
  i1146.colorSelected = new pc.Color(i1147[8], i1147[9], i1147[10], i1147[11])
  return i1146
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerObjectList"] = function (request, data, root) {
  var i1148 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerObjectList' )
  var i1149 = data
  request.r(i1149[0], i1149[1], 0, i1148, 'nextButtonText')
  request.r(i1149[2], i1149[3], 0, i1148, 'previousButtonText')
  request.r(i1149[4], i1149[5], 0, i1148, 'nameLabel')
  request.r(i1149[6], i1149[7], 0, i1148, 'valueLabel')
  i1148.colorDefault = new pc.Color(i1149[8], i1149[9], i1149[10], i1149[11])
  i1148.colorSelected = new pc.Color(i1149[12], i1149[13], i1149[14], i1149[15])
  return i1148
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerObjectPopupField"] = function (request, data, root) {
  var i1150 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerObjectPopupField' )
  var i1151 = data
  request.r(i1151[0], i1151[1], 0, i1150, 'nextButtonText')
  request.r(i1151[2], i1151[3], 0, i1150, 'previousButtonText')
  request.r(i1151[4], i1151[5], 0, i1150, 'nameLabel')
  request.r(i1151[6], i1151[7], 0, i1150, 'valueLabel')
  i1150.colorDefault = new pc.Color(i1151[8], i1151[9], i1151[10], i1151[11])
  i1150.colorSelected = new pc.Color(i1151[12], i1151[13], i1151[14], i1151[15])
  return i1150
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerRenderingLayerField"] = function (request, data, root) {
  var i1152 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerRenderingLayerField' )
  var i1153 = data
  request.r(i1153[0], i1153[1], 0, i1152, 'nameLabel')
  request.r(i1153[2], i1153[3], 0, i1152, 'valueToggle')
  var i1155 = i1153[4]
  var i1154 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.Rendering.UI.DebugUIHandlerIndirectToggle')))
  for(var i = 0; i < i1155.length; i += 2) {
  request.r(i1155[i + 0], i1155[i + 1], 1, i1154, '')
  }
  i1152.toggles = i1154
  i1152.colorDefault = new pc.Color(i1153[5], i1153[6], i1153[7], i1153[8])
  i1152.colorSelected = new pc.Color(i1153[9], i1153[10], i1153[11], i1153[12])
  return i1152
}

Deserializers["UnityEngine.Rendering.UI.DebugUIHandlerPersistentCanvas"] = function (request, data, root) {
  var i1156 = root || request.c( 'UnityEngine.Rendering.UI.DebugUIHandlerPersistentCanvas' )
  var i1157 = data
  request.r(i1157[0], i1157[1], 0, i1156, 'panel')
  request.r(i1157[2], i1157[3], 0, i1156, 'valuePrefab')
  return i1156
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.UniversalRenderPipelineAsset"] = function (request, data, root) {
  var i1158 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.UniversalRenderPipelineAsset' )
  var i1159 = data
  i1158.AdditionalLightsRenderingMode = i1159[0]
  i1158.LightRenderingMode = request.d('Luna.Unity.DTO.UnityEngine.Assets.LightRenderingMode', i1159[1], i1158.LightRenderingMode)
  i1158.MainLightRenderingModeValue = i1159[2]
  i1158.SupportsMainLightShadows = !!i1159[3]
  i1158.MixedLightingSupported = !!i1159[4]
  i1158.MainLightShadowmapResolutionValue = i1159[5]
  i1158.SupportsSoftShadows = !!i1159[6]
  i1158.SoftShadowQualityValue = i1159[7]
  i1158.ShadowDistance = i1159[8]
  i1158.ShadowCascadeCount = i1159[9]
  i1158.Cascade2Split = i1159[10]
  i1158.Cascade3Split = new pc.Vec2( i1159[11], i1159[12] )
  i1158.Cascade4Split = new pc.Vec3( i1159[13], i1159[14], i1159[15] )
  i1158.CascadeBorder = i1159[16]
  i1158.ShadowDepthBias = i1159[17]
  i1158.ShadowNormalBias = i1159[18]
  i1158.RequireDepthTexture = !!i1159[19]
  i1158.RequireOpaqueTexture = !!i1159[20]
  i1158.scriptableRendererData = request.d('Luna.Unity.DTO.UnityEngine.Assets.ScriptableRendererData', i1159[21], i1158.scriptableRendererData)
  return i1158
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.LightRenderingMode"] = function (request, data, root) {
  var i1160 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.LightRenderingMode' )
  var i1161 = data
  i1160.Disabled = i1161[0]
  i1160.PerVertex = i1161[1]
  i1160.PerPixel = i1161[2]
  return i1160
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ScriptableRendererData"] = function (request, data, root) {
  var i1162 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ScriptableRendererData' )
  var i1163 = data
  i1162.opaqueLayerMask = i1163[0]
  i1162.transparentLayerMask = i1163[1]
  var i1165 = i1163[2]
  var i1164 = []
  for(var i = 0; i < i1165.length; i += 1) {
    i1164.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.RenderObjects', i1165[i + 0]) );
  }
  i1162.RenderObjectsFeatures = i1164
  i1162.name = i1163[3]
  return i1162
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.RenderObjects"] = function (request, data, root) {
  var i1168 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.RenderObjects' )
  var i1169 = data
  i1168.settings = request.d('Luna.Unity.DTO.UnityEngine.Assets.RenderObjects+RenderObjectsSettings', i1169[0], i1168.settings)
  i1168.name = i1169[1]
  i1168.typeName = i1169[2]
  return i1168
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader"] = function (request, data, root) {
  var i1170 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader' )
  var i1171 = data
  var i1173 = i1171[0]
  var i1172 = new (System.Collections.Generic.List$1(Bridge.ns('Luna.Unity.DTO.UnityEngine.Assets.Shader+ShaderCompilationError')))
  for(var i = 0; i < i1173.length; i += 1) {
    i1172.add(request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+ShaderCompilationError', i1173[i + 0]));
  }
  i1170.ShaderCompilationErrors = i1172
  i1170.name = i1171[1]
  i1170.guid = i1171[2]
  var i1175 = i1171[3]
  var i1174 = []
  for(var i = 0; i < i1175.length; i += 1) {
    i1174.push( i1175[i + 0] );
  }
  i1170.shaderDefinedKeywords = i1174
  var i1177 = i1171[4]
  var i1176 = []
  for(var i = 0; i < i1177.length; i += 1) {
    i1176.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass', i1177[i + 0]) );
  }
  i1170.passes = i1176
  var i1179 = i1171[5]
  var i1178 = []
  for(var i = 0; i < i1179.length; i += 1) {
    i1178.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+UsePass', i1179[i + 0]) );
  }
  i1170.usePasses = i1178
  var i1181 = i1171[6]
  var i1180 = []
  for(var i = 0; i < i1181.length; i += 1) {
    i1180.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+DefaultParameterValue', i1181[i + 0]) );
  }
  i1170.defaultParameterValues = i1180
  request.r(i1171[7], i1171[8], 0, i1170, 'unityFallbackShader')
  i1170.readDepth = !!i1171[9]
  i1170.hasDepthOnlyPass = !!i1171[10]
  i1170.isCreatedByShaderGraph = !!i1171[11]
  i1170.disableBatching = !!i1171[12]
  i1170.compiled = !!i1171[13]
  return i1170
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+ShaderCompilationError"] = function (request, data, root) {
  var i1184 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+ShaderCompilationError' )
  var i1185 = data
  i1184.shaderName = i1185[0]
  i1184.errorMessage = i1185[1]
  return i1184
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass"] = function (request, data, root) {
  var i1190 = root || new pc.UnityShaderPass()
  var i1191 = data
  i1190.id = i1191[0]
  i1190.subShaderIndex = i1191[1]
  i1190.name = i1191[2]
  i1190.passType = i1191[3]
  i1190.grabPassTextureName = i1191[4]
  i1190.usePass = !!i1191[5]
  i1190.zTest = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1191[6], i1190.zTest)
  i1190.zWrite = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1191[7], i1190.zWrite)
  i1190.culling = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1191[8], i1190.culling)
  i1190.blending = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Blending', i1191[9], i1190.blending)
  i1190.alphaBlending = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Blending', i1191[10], i1190.alphaBlending)
  i1190.colorWriteMask = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1191[11], i1190.colorWriteMask)
  i1190.offsetUnits = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1191[12], i1190.offsetUnits)
  i1190.offsetFactor = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1191[13], i1190.offsetFactor)
  i1190.stencilRef = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1191[14], i1190.stencilRef)
  i1190.stencilReadMask = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1191[15], i1190.stencilReadMask)
  i1190.stencilWriteMask = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1191[16], i1190.stencilWriteMask)
  i1190.stencilOp = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp', i1191[17], i1190.stencilOp)
  i1190.stencilOpFront = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp', i1191[18], i1190.stencilOpFront)
  i1190.stencilOpBack = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp', i1191[19], i1190.stencilOpBack)
  var i1193 = i1191[20]
  var i1192 = []
  for(var i = 0; i < i1193.length; i += 1) {
    i1192.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Tag', i1193[i + 0]) );
  }
  i1190.tags = i1192
  var i1195 = i1191[21]
  var i1194 = []
  for(var i = 0; i < i1195.length; i += 1) {
    i1194.push( i1195[i + 0] );
  }
  i1190.passDefinedKeywords = i1194
  var i1197 = i1191[22]
  var i1196 = []
  for(var i = 0; i < i1197.length; i += 1) {
    i1196.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+KeywordGroup', i1197[i + 0]) );
  }
  i1190.passDefinedKeywordGroups = i1196
  var i1199 = i1191[23]
  var i1198 = []
  for(var i = 0; i < i1199.length; i += 1) {
    i1198.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Variant', i1199[i + 0]) );
  }
  i1190.variants = i1198
  var i1201 = i1191[24]
  var i1200 = []
  for(var i = 0; i < i1201.length; i += 1) {
    i1200.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Variant', i1201[i + 0]) );
  }
  i1190.excludedVariants = i1200
  i1190.hasDepthReader = !!i1191[25]
  return i1190
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value"] = function (request, data, root) {
  var i1202 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value' )
  var i1203 = data
  i1202.val = i1203[0]
  i1202.name = i1203[1]
  return i1202
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Blending"] = function (request, data, root) {
  var i1204 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Blending' )
  var i1205 = data
  i1204.src = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1205[0], i1204.src)
  i1204.dst = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1205[1], i1204.dst)
  i1204.op = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1205[2], i1204.op)
  return i1204
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp"] = function (request, data, root) {
  var i1206 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp' )
  var i1207 = data
  i1206.pass = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1207[0], i1206.pass)
  i1206.fail = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1207[1], i1206.fail)
  i1206.zFail = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1207[2], i1206.zFail)
  i1206.comp = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1207[3], i1206.comp)
  return i1206
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Tag"] = function (request, data, root) {
  var i1210 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Tag' )
  var i1211 = data
  i1210.name = i1211[0]
  i1210.value = i1211[1]
  return i1210
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+KeywordGroup"] = function (request, data, root) {
  var i1214 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+KeywordGroup' )
  var i1215 = data
  var i1217 = i1215[0]
  var i1216 = []
  for(var i = 0; i < i1217.length; i += 1) {
    i1216.push( i1217[i + 0] );
  }
  i1214.keywords = i1216
  i1214.hasDiscard = !!i1215[1]
  return i1214
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Variant"] = function (request, data, root) {
  var i1220 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Variant' )
  var i1221 = data
  i1220.passId = i1221[0]
  i1220.subShaderIndex = i1221[1]
  var i1223 = i1221[2]
  var i1222 = []
  for(var i = 0; i < i1223.length; i += 1) {
    i1222.push( i1223[i + 0] );
  }
  i1220.keywords = i1222
  i1220.vertexProgram = i1221[3]
  i1220.fragmentProgram = i1221[4]
  i1220.exportedForWebGl2 = !!i1221[5]
  i1220.readDepth = !!i1221[6]
  return i1220
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+UsePass"] = function (request, data, root) {
  var i1226 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+UsePass' )
  var i1227 = data
  request.r(i1227[0], i1227[1], 0, i1226, 'shader')
  i1226.pass = i1227[2]
  return i1226
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+DefaultParameterValue"] = function (request, data, root) {
  var i1230 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+DefaultParameterValue' )
  var i1231 = data
  i1230.name = i1231[0]
  i1230.type = i1231[1]
  i1230.value = new pc.Vec4( i1231[2], i1231[3], i1231[4], i1231[5] )
  i1230.textureValue = i1231[6]
  i1230.shaderPropertyFlag = i1231[7]
  return i1230
}

Deserializers["Luna.Unity.DTO.UnityEngine.Textures.Sprite"] = function (request, data, root) {
  var i1232 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Textures.Sprite' )
  var i1233 = data
  i1232.name = i1233[0]
  request.r(i1233[1], i1233[2], 0, i1232, 'texture')
  i1232.aabb = i1233[3]
  i1232.vertices = i1233[4]
  i1232.triangles = i1233[5]
  i1232.textureRect = UnityEngine.Rect.MinMaxRect(i1233[6], i1233[7], i1233[8], i1233[9])
  i1232.packedRect = UnityEngine.Rect.MinMaxRect(i1233[10], i1233[11], i1233[12], i1233[13])
  i1232.border = new pc.Vec4( i1233[14], i1233[15], i1233[16], i1233[17] )
  i1232.transparency = i1233[18]
  i1232.bounds = i1233[19]
  i1232.pixelsPerUnit = i1233[20]
  i1232.textureWidth = i1233[21]
  i1232.textureHeight = i1233[22]
  i1232.nativeSize = new pc.Vec2( i1233[23], i1233[24] )
  i1232.pivot = new pc.Vec2( i1233[25], i1233[26] )
  i1232.textureRectOffset = new pc.Vec2( i1233[27], i1233[28] )
  return i1232
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.AudioClip"] = function (request, data, root) {
  var i1234 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.AudioClip' )
  var i1235 = data
  i1234.name = i1235[0]
  return i1234
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Font"] = function (request, data, root) {
  var i1236 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Font' )
  var i1237 = data
  i1236.name = i1237[0]
  i1236.ascent = i1237[1]
  i1236.originalLineHeight = i1237[2]
  i1236.fontSize = i1237[3]
  var i1239 = i1237[4]
  var i1238 = []
  for(var i = 0; i < i1239.length; i += 1) {
    i1238.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Font+CharacterInfo', i1239[i + 0]) );
  }
  i1236.characterInfo = i1238
  request.r(i1237[5], i1237[6], 0, i1236, 'texture')
  i1236.originalFontSize = i1237[7]
  return i1236
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Font+CharacterInfo"] = function (request, data, root) {
  var i1242 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Font+CharacterInfo' )
  var i1243 = data
  i1242.index = i1243[0]
  i1242.advance = i1243[1]
  i1242.bearing = i1243[2]
  i1242.glyphWidth = i1243[3]
  i1242.glyphHeight = i1243[4]
  i1242.minX = i1243[5]
  i1242.maxX = i1243[6]
  i1242.minY = i1243[7]
  i1242.maxY = i1243[8]
  i1242.uvBottomLeftX = i1243[9]
  i1242.uvBottomLeftY = i1243[10]
  i1242.uvBottomRightX = i1243[11]
  i1242.uvBottomRightY = i1243[12]
  i1242.uvTopLeftX = i1243[13]
  i1242.uvTopLeftY = i1243[14]
  i1242.uvTopRightX = i1243[15]
  i1242.uvTopRightY = i1243[16]
  return i1242
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.TextAsset"] = function (request, data, root) {
  var i1244 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.TextAsset' )
  var i1245 = data
  i1244.name = i1245[0]
  i1244.bytes64 = i1245[1]
  i1244.data = i1245[2]
  return i1244
}

Deserializers["TMPro.TMP_FontAsset"] = function (request, data, root) {
  var i1246 = root || request.c( 'TMPro.TMP_FontAsset' )
  var i1247 = data
  i1246.normalStyle = i1247[0]
  i1246.normalSpacingOffset = i1247[1]
  i1246.boldStyle = i1247[2]
  i1246.boldSpacing = i1247[3]
  i1246.italicStyle = i1247[4]
  i1246.tabSize = i1247[5]
  request.r(i1247[6], i1247[7], 0, i1246, 'atlas')
  i1246.m_SourceFontFileGUID = i1247[8]
  i1246.m_CreationSettings = request.d('TMPro.FontAssetCreationSettings', i1247[9], i1246.m_CreationSettings)
  request.r(i1247[10], i1247[11], 0, i1246, 'm_SourceFontFile')
  i1246.m_SourceFontFilePath = i1247[12]
  i1246.m_AtlasPopulationMode = i1247[13]
  i1246.InternalDynamicOS = !!i1247[14]
  var i1249 = i1247[15]
  var i1248 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.TextCore.Glyph')))
  for(var i = 0; i < i1249.length; i += 1) {
    i1248.add(request.d('UnityEngine.TextCore.Glyph', i1249[i + 0]));
  }
  i1246.m_GlyphTable = i1248
  var i1251 = i1247[16]
  var i1250 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_Character')))
  for(var i = 0; i < i1251.length; i += 1) {
    i1250.add(request.d('TMPro.TMP_Character', i1251[i + 0]));
  }
  i1246.m_CharacterTable = i1250
  var i1253 = i1247[17]
  var i1252 = []
  for(var i = 0; i < i1253.length; i += 2) {
  request.r(i1253[i + 0], i1253[i + 1], 2, i1252, '')
  }
  i1246.m_AtlasTextures = i1252
  i1246.m_AtlasTextureIndex = i1247[18]
  i1246.m_IsMultiAtlasTexturesEnabled = !!i1247[19]
  i1246.m_GetFontFeatures = !!i1247[20]
  i1246.m_ClearDynamicDataOnBuild = !!i1247[21]
  i1246.m_AtlasWidth = i1247[22]
  i1246.m_AtlasHeight = i1247[23]
  i1246.m_AtlasPadding = i1247[24]
  i1246.m_AtlasRenderMode = i1247[25]
  var i1255 = i1247[26]
  var i1254 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.TextCore.GlyphRect')))
  for(var i = 0; i < i1255.length; i += 1) {
    i1254.add(request.d('UnityEngine.TextCore.GlyphRect', i1255[i + 0]));
  }
  i1246.m_UsedGlyphRects = i1254
  var i1257 = i1247[27]
  var i1256 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.TextCore.GlyphRect')))
  for(var i = 0; i < i1257.length; i += 1) {
    i1256.add(request.d('UnityEngine.TextCore.GlyphRect', i1257[i + 0]));
  }
  i1246.m_FreeGlyphRects = i1256
  i1246.m_FontFeatureTable = request.d('TMPro.TMP_FontFeatureTable', i1247[28], i1246.m_FontFeatureTable)
  i1246.m_ShouldReimportFontFeatures = !!i1247[29]
  var i1259 = i1247[30]
  var i1258 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_FontAsset')))
  for(var i = 0; i < i1259.length; i += 2) {
  request.r(i1259[i + 0], i1259[i + 1], 1, i1258, '')
  }
  i1246.m_FallbackFontAssetTable = i1258
  var i1261 = i1247[31]
  var i1260 = []
  for(var i = 0; i < i1261.length; i += 1) {
    i1260.push( request.d('TMPro.TMP_FontWeightPair', i1261[i + 0]) );
  }
  i1246.m_FontWeightTable = i1260
  var i1263 = i1247[32]
  var i1262 = []
  for(var i = 0; i < i1263.length; i += 1) {
    i1262.push( request.d('TMPro.TMP_FontWeightPair', i1263[i + 0]) );
  }
  i1246.fontWeights = i1262
  i1246.m_fontInfo = request.d('TMPro.FaceInfo_Legacy', i1247[33], i1246.m_fontInfo)
  var i1265 = i1247[34]
  var i1264 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_Glyph')))
  for(var i = 0; i < i1265.length; i += 1) {
    i1264.add(request.d('TMPro.TMP_Glyph', i1265[i + 0]));
  }
  i1246.m_glyphInfoList = i1264
  i1246.m_KerningTable = request.d('TMPro.KerningTable', i1247[35], i1246.m_KerningTable)
  var i1267 = i1247[36]
  var i1266 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_FontAsset')))
  for(var i = 0; i < i1267.length; i += 2) {
  request.r(i1267[i + 0], i1267[i + 1], 1, i1266, '')
  }
  i1246.fallbackFontAssets = i1266
  i1246.m_Version = i1247[37]
  i1246.m_FaceInfo = request.d('UnityEngine.TextCore.FaceInfo', i1247[38], i1246.m_FaceInfo)
  request.r(i1247[39], i1247[40], 0, i1246, 'm_Material')
  return i1246
}

Deserializers["TMPro.FontAssetCreationSettings"] = function (request, data, root) {
  var i1268 = root || request.c( 'TMPro.FontAssetCreationSettings' )
  var i1269 = data
  i1268.sourceFontFileName = i1269[0]
  i1268.sourceFontFileGUID = i1269[1]
  i1268.faceIndex = i1269[2]
  i1268.pointSizeSamplingMode = i1269[3]
  i1268.pointSize = i1269[4]
  i1268.padding = i1269[5]
  i1268.paddingMode = i1269[6]
  i1268.packingMode = i1269[7]
  i1268.atlasWidth = i1269[8]
  i1268.atlasHeight = i1269[9]
  i1268.characterSetSelectionMode = i1269[10]
  i1268.characterSequence = i1269[11]
  i1268.referencedFontAssetGUID = i1269[12]
  i1268.referencedTextAssetGUID = i1269[13]
  i1268.fontStyle = i1269[14]
  i1268.fontStyleModifier = i1269[15]
  i1268.renderMode = i1269[16]
  i1268.includeFontFeatures = !!i1269[17]
  return i1268
}

Deserializers["UnityEngine.TextCore.Glyph"] = function (request, data, root) {
  var i1272 = root || request.c( 'UnityEngine.TextCore.Glyph' )
  var i1273 = data
  i1272.m_Index = i1273[0]
  i1272.m_Metrics = request.d('UnityEngine.TextCore.GlyphMetrics', i1273[1], i1272.m_Metrics)
  i1272.m_GlyphRect = request.d('UnityEngine.TextCore.GlyphRect', i1273[2], i1272.m_GlyphRect)
  i1272.m_Scale = i1273[3]
  i1272.m_AtlasIndex = i1273[4]
  i1272.m_ClassDefinitionType = i1273[5]
  return i1272
}

Deserializers["UnityEngine.TextCore.GlyphMetrics"] = function (request, data, root) {
  var i1274 = root || request.c( 'UnityEngine.TextCore.GlyphMetrics' )
  var i1275 = data
  i1274.m_Width = i1275[0]
  i1274.m_Height = i1275[1]
  i1274.m_HorizontalBearingX = i1275[2]
  i1274.m_HorizontalBearingY = i1275[3]
  i1274.m_HorizontalAdvance = i1275[4]
  return i1274
}

Deserializers["UnityEngine.TextCore.GlyphRect"] = function (request, data, root) {
  var i1276 = root || request.c( 'UnityEngine.TextCore.GlyphRect' )
  var i1277 = data
  i1276.m_X = i1277[0]
  i1276.m_Y = i1277[1]
  i1276.m_Width = i1277[2]
  i1276.m_Height = i1277[3]
  return i1276
}

Deserializers["TMPro.TMP_Character"] = function (request, data, root) {
  var i1280 = root || request.c( 'TMPro.TMP_Character' )
  var i1281 = data
  i1280.m_ElementType = i1281[0]
  i1280.m_Unicode = i1281[1]
  i1280.m_GlyphIndex = i1281[2]
  i1280.m_Scale = i1281[3]
  return i1280
}

Deserializers["TMPro.TMP_FontFeatureTable"] = function (request, data, root) {
  var i1286 = root || request.c( 'TMPro.TMP_FontFeatureTable' )
  var i1287 = data
  var i1289 = i1287[0]
  var i1288 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.MultipleSubstitutionRecord')))
  for(var i = 0; i < i1289.length; i += 1) {
    i1288.add(request.d('TMPro.MultipleSubstitutionRecord', i1289[i + 0]));
  }
  i1286.m_MultipleSubstitutionRecords = i1288
  var i1291 = i1287[1]
  var i1290 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.LigatureSubstitutionRecord')))
  for(var i = 0; i < i1291.length; i += 1) {
    i1290.add(request.d('TMPro.LigatureSubstitutionRecord', i1291[i + 0]));
  }
  i1286.m_LigatureSubstitutionRecords = i1290
  var i1293 = i1287[2]
  var i1292 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.TextCore.LowLevel.GlyphPairAdjustmentRecord')))
  for(var i = 0; i < i1293.length; i += 1) {
    i1292.add(request.d('UnityEngine.TextCore.LowLevel.GlyphPairAdjustmentRecord', i1293[i + 0]));
  }
  i1286.m_GlyphPairAdjustmentRecords = i1292
  var i1295 = i1287[3]
  var i1294 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.MarkToBaseAdjustmentRecord')))
  for(var i = 0; i < i1295.length; i += 1) {
    i1294.add(request.d('TMPro.MarkToBaseAdjustmentRecord', i1295[i + 0]));
  }
  i1286.m_MarkToBaseAdjustmentRecords = i1294
  var i1297 = i1287[4]
  var i1296 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.MarkToMarkAdjustmentRecord')))
  for(var i = 0; i < i1297.length; i += 1) {
    i1296.add(request.d('TMPro.MarkToMarkAdjustmentRecord', i1297[i + 0]));
  }
  i1286.m_MarkToMarkAdjustmentRecords = i1296
  return i1286
}

Deserializers["TMPro.MultipleSubstitutionRecord"] = function (request, data, root) {
  var i1300 = root || request.c( 'TMPro.MultipleSubstitutionRecord' )
  var i1301 = data
  i1300.m_TargetGlyphID = i1301[0]
  i1300.m_SubstituteGlyphIDs = i1301[1]
  return i1300
}

Deserializers["TMPro.LigatureSubstitutionRecord"] = function (request, data, root) {
  var i1304 = root || request.c( 'TMPro.LigatureSubstitutionRecord' )
  var i1305 = data
  i1304.m_ComponentGlyphIDs = i1305[0]
  i1304.m_LigatureGlyphID = i1305[1]
  return i1304
}

Deserializers["UnityEngine.TextCore.LowLevel.GlyphPairAdjustmentRecord"] = function (request, data, root) {
  var i1308 = root || request.c( 'UnityEngine.TextCore.LowLevel.GlyphPairAdjustmentRecord' )
  var i1309 = data
  i1308.m_FirstAdjustmentRecord = request.d('UnityEngine.TextCore.LowLevel.GlyphAdjustmentRecord', i1309[0], i1308.m_FirstAdjustmentRecord)
  i1308.m_SecondAdjustmentRecord = request.d('UnityEngine.TextCore.LowLevel.GlyphAdjustmentRecord', i1309[1], i1308.m_SecondAdjustmentRecord)
  i1308.m_FeatureLookupFlags = i1309[2]
  return i1308
}

Deserializers["UnityEngine.TextCore.LowLevel.GlyphAdjustmentRecord"] = function (request, data, root) {
  var i1310 = root || request.c( 'UnityEngine.TextCore.LowLevel.GlyphAdjustmentRecord' )
  var i1311 = data
  i1310.m_GlyphIndex = i1311[0]
  i1310.m_GlyphValueRecord = request.d('UnityEngine.TextCore.LowLevel.GlyphValueRecord', i1311[1], i1310.m_GlyphValueRecord)
  return i1310
}

Deserializers["UnityEngine.TextCore.LowLevel.GlyphValueRecord"] = function (request, data, root) {
  var i1312 = root || request.c( 'UnityEngine.TextCore.LowLevel.GlyphValueRecord' )
  var i1313 = data
  i1312.m_XPlacement = i1313[0]
  i1312.m_YPlacement = i1313[1]
  i1312.m_XAdvance = i1313[2]
  i1312.m_YAdvance = i1313[3]
  return i1312
}

Deserializers["TMPro.MarkToBaseAdjustmentRecord"] = function (request, data, root) {
  var i1316 = root || request.c( 'TMPro.MarkToBaseAdjustmentRecord' )
  var i1317 = data
  i1316.m_BaseGlyphID = i1317[0]
  i1316.m_BaseGlyphAnchorPoint = request.d('TMPro.GlyphAnchorPoint', i1317[1], i1316.m_BaseGlyphAnchorPoint)
  i1316.m_MarkGlyphID = i1317[2]
  i1316.m_MarkPositionAdjustment = request.d('TMPro.MarkPositionAdjustment', i1317[3], i1316.m_MarkPositionAdjustment)
  return i1316
}

Deserializers["TMPro.GlyphAnchorPoint"] = function (request, data, root) {
  var i1318 = root || request.c( 'TMPro.GlyphAnchorPoint' )
  var i1319 = data
  i1318.m_XCoordinate = i1319[0]
  i1318.m_YCoordinate = i1319[1]
  return i1318
}

Deserializers["TMPro.MarkPositionAdjustment"] = function (request, data, root) {
  var i1320 = root || request.c( 'TMPro.MarkPositionAdjustment' )
  var i1321 = data
  i1320.m_XPositionAdjustment = i1321[0]
  i1320.m_YPositionAdjustment = i1321[1]
  return i1320
}

Deserializers["TMPro.MarkToMarkAdjustmentRecord"] = function (request, data, root) {
  var i1324 = root || request.c( 'TMPro.MarkToMarkAdjustmentRecord' )
  var i1325 = data
  i1324.m_BaseMarkGlyphID = i1325[0]
  i1324.m_BaseMarkGlyphAnchorPoint = request.d('TMPro.GlyphAnchorPoint', i1325[1], i1324.m_BaseMarkGlyphAnchorPoint)
  i1324.m_CombiningMarkGlyphID = i1325[2]
  i1324.m_CombiningMarkPositionAdjustment = request.d('TMPro.MarkPositionAdjustment', i1325[3], i1324.m_CombiningMarkPositionAdjustment)
  return i1324
}

Deserializers["TMPro.TMP_FontWeightPair"] = function (request, data, root) {
  var i1330 = root || request.c( 'TMPro.TMP_FontWeightPair' )
  var i1331 = data
  request.r(i1331[0], i1331[1], 0, i1330, 'regularTypeface')
  request.r(i1331[2], i1331[3], 0, i1330, 'italicTypeface')
  return i1330
}

Deserializers["TMPro.FaceInfo_Legacy"] = function (request, data, root) {
  var i1332 = root || request.c( 'TMPro.FaceInfo_Legacy' )
  var i1333 = data
  i1332.Name = i1333[0]
  i1332.PointSize = i1333[1]
  i1332.Scale = i1333[2]
  i1332.CharacterCount = i1333[3]
  i1332.LineHeight = i1333[4]
  i1332.Baseline = i1333[5]
  i1332.Ascender = i1333[6]
  i1332.CapHeight = i1333[7]
  i1332.Descender = i1333[8]
  i1332.CenterLine = i1333[9]
  i1332.SuperscriptOffset = i1333[10]
  i1332.SubscriptOffset = i1333[11]
  i1332.SubSize = i1333[12]
  i1332.Underline = i1333[13]
  i1332.UnderlineThickness = i1333[14]
  i1332.strikethrough = i1333[15]
  i1332.strikethroughThickness = i1333[16]
  i1332.TabWidth = i1333[17]
  i1332.Padding = i1333[18]
  i1332.AtlasWidth = i1333[19]
  i1332.AtlasHeight = i1333[20]
  return i1332
}

Deserializers["TMPro.TMP_Glyph"] = function (request, data, root) {
  var i1336 = root || request.c( 'TMPro.TMP_Glyph' )
  var i1337 = data
  i1336.id = i1337[0]
  i1336.x = i1337[1]
  i1336.y = i1337[2]
  i1336.width = i1337[3]
  i1336.height = i1337[4]
  i1336.xOffset = i1337[5]
  i1336.yOffset = i1337[6]
  i1336.xAdvance = i1337[7]
  i1336.scale = i1337[8]
  return i1336
}

Deserializers["TMPro.KerningTable"] = function (request, data, root) {
  var i1338 = root || request.c( 'TMPro.KerningTable' )
  var i1339 = data
  var i1341 = i1339[0]
  var i1340 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.KerningPair')))
  for(var i = 0; i < i1341.length; i += 1) {
    i1340.add(request.d('TMPro.KerningPair', i1341[i + 0]));
  }
  i1338.kerningPairs = i1340
  return i1338
}

Deserializers["TMPro.KerningPair"] = function (request, data, root) {
  var i1344 = root || request.c( 'TMPro.KerningPair' )
  var i1345 = data
  i1344.xOffset = i1345[0]
  i1344.m_FirstGlyph = i1345[1]
  i1344.m_FirstGlyphAdjustments = request.d('TMPro.GlyphValueRecord_Legacy', i1345[2], i1344.m_FirstGlyphAdjustments)
  i1344.m_SecondGlyph = i1345[3]
  i1344.m_SecondGlyphAdjustments = request.d('TMPro.GlyphValueRecord_Legacy', i1345[4], i1344.m_SecondGlyphAdjustments)
  i1344.m_IgnoreSpacingAdjustments = !!i1345[5]
  return i1344
}

Deserializers["UnityEngine.TextCore.FaceInfo"] = function (request, data, root) {
  var i1346 = root || request.c( 'UnityEngine.TextCore.FaceInfo' )
  var i1347 = data
  i1346.m_FaceIndex = i1347[0]
  i1346.m_FamilyName = i1347[1]
  i1346.m_StyleName = i1347[2]
  i1346.m_PointSize = i1347[3]
  i1346.m_Scale = i1347[4]
  i1346.m_UnitsPerEM = i1347[5]
  i1346.m_LineHeight = i1347[6]
  i1346.m_AscentLine = i1347[7]
  i1346.m_CapLine = i1347[8]
  i1346.m_MeanLine = i1347[9]
  i1346.m_Baseline = i1347[10]
  i1346.m_DescentLine = i1347[11]
  i1346.m_SuperscriptOffset = i1347[12]
  i1346.m_SuperscriptSize = i1347[13]
  i1346.m_SubscriptOffset = i1347[14]
  i1346.m_SubscriptSize = i1347[15]
  i1346.m_UnderlineOffset = i1347[16]
  i1346.m_UnderlineThickness = i1347[17]
  i1346.m_StrikethroughOffset = i1347[18]
  i1346.m_StrikethroughThickness = i1347[19]
  i1346.m_TabWidth = i1347[20]
  return i1346
}

Deserializers["CustomGridShape"] = function (request, data, root) {
  var i1348 = root || request.c( 'CustomGridShape' )
  var i1349 = data
  var i1351 = i1349[0]
  var i1350 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.Vector2Int')))
  for(var i = 0; i < i1351.length; i += 2) {
    i1350.add(new pc.Vec2( i1351[i + 0], i1351[i + 1] ));
  }
  i1348.cells = i1350
  return i1348
}

Deserializers["ObjectSet"] = function (request, data, root) {
  var i1352 = root || request.c( 'ObjectSet' )
  var i1353 = data
  i1352.Name = i1353[0]
  request.r(i1353[1], i1353[2], 0, i1352, 'RewardCardSprite')
  var i1355 = i1353[3]
  var i1354 = new (System.Collections.Generic.List$1(Bridge.ns('ObjectMapping')))
  for(var i = 0; i < i1355.length; i += 1) {
    i1354.add(request.d('ObjectMapping', i1355[i + 0]));
  }
  i1352.Mappings = i1354
  return i1352
}

Deserializers["ObjectMapping"] = function (request, data, root) {
  var i1358 = root || request.c( 'ObjectMapping' )
  var i1359 = data
  i1358.GenericId = i1359[0]
  i1358.ConcreteType = i1359[1]
  return i1358
}

Deserializers["TMPro.TMP_SpriteAsset"] = function (request, data, root) {
  var i1360 = root || request.c( 'TMPro.TMP_SpriteAsset' )
  var i1361 = data
  request.r(i1361[0], i1361[1], 0, i1360, 'spriteSheet')
  var i1363 = i1361[2]
  var i1362 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_Sprite')))
  for(var i = 0; i < i1363.length; i += 1) {
    i1362.add(request.d('TMPro.TMP_Sprite', i1363[i + 0]));
  }
  i1360.spriteInfoList = i1362
  var i1365 = i1361[3]
  var i1364 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_SpriteAsset')))
  for(var i = 0; i < i1365.length; i += 2) {
  request.r(i1365[i + 0], i1365[i + 1], 1, i1364, '')
  }
  i1360.fallbackSpriteAssets = i1364
  var i1367 = i1361[4]
  var i1366 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_SpriteCharacter')))
  for(var i = 0; i < i1367.length; i += 1) {
    i1366.add(request.d('TMPro.TMP_SpriteCharacter', i1367[i + 0]));
  }
  i1360.m_SpriteCharacterTable = i1366
  var i1369 = i1361[5]
  var i1368 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_SpriteGlyph')))
  for(var i = 0; i < i1369.length; i += 1) {
    i1368.add(request.d('TMPro.TMP_SpriteGlyph', i1369[i + 0]));
  }
  i1360.m_GlyphTable = i1368
  i1360.m_Version = i1361[6]
  i1360.m_FaceInfo = request.d('UnityEngine.TextCore.FaceInfo', i1361[7], i1360.m_FaceInfo)
  request.r(i1361[8], i1361[9], 0, i1360, 'm_Material')
  return i1360
}

Deserializers["TMPro.TMP_Sprite"] = function (request, data, root) {
  var i1372 = root || request.c( 'TMPro.TMP_Sprite' )
  var i1373 = data
  i1372.name = i1373[0]
  i1372.hashCode = i1373[1]
  i1372.unicode = i1373[2]
  i1372.pivot = new pc.Vec2( i1373[3], i1373[4] )
  request.r(i1373[5], i1373[6], 0, i1372, 'sprite')
  i1372.id = i1373[7]
  i1372.x = i1373[8]
  i1372.y = i1373[9]
  i1372.width = i1373[10]
  i1372.height = i1373[11]
  i1372.xOffset = i1373[12]
  i1372.yOffset = i1373[13]
  i1372.xAdvance = i1373[14]
  i1372.scale = i1373[15]
  return i1372
}

Deserializers["TMPro.TMP_SpriteCharacter"] = function (request, data, root) {
  var i1378 = root || request.c( 'TMPro.TMP_SpriteCharacter' )
  var i1379 = data
  i1378.m_Name = i1379[0]
  i1378.m_ElementType = i1379[1]
  i1378.m_Unicode = i1379[2]
  i1378.m_GlyphIndex = i1379[3]
  i1378.m_Scale = i1379[4]
  return i1378
}

Deserializers["TMPro.TMP_SpriteGlyph"] = function (request, data, root) {
  var i1382 = root || request.c( 'TMPro.TMP_SpriteGlyph' )
  var i1383 = data
  request.r(i1383[0], i1383[1], 0, i1382, 'sprite')
  i1382.m_Index = i1383[2]
  i1382.m_Metrics = request.d('UnityEngine.TextCore.GlyphMetrics', i1383[3], i1382.m_Metrics)
  i1382.m_GlyphRect = request.d('UnityEngine.TextCore.GlyphRect', i1383[4], i1382.m_GlyphRect)
  i1382.m_Scale = i1383[5]
  i1382.m_AtlasIndex = i1383[6]
  i1382.m_ClassDefinitionType = i1383[7]
  return i1382
}

Deserializers["TMPro.TMP_StyleSheet"] = function (request, data, root) {
  var i1384 = root || request.c( 'TMPro.TMP_StyleSheet' )
  var i1385 = data
  var i1387 = i1385[0]
  var i1386 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_Style')))
  for(var i = 0; i < i1387.length; i += 1) {
    i1386.add(request.d('TMPro.TMP_Style', i1387[i + 0]));
  }
  i1384.m_StyleList = i1386
  return i1384
}

Deserializers["TMPro.TMP_Style"] = function (request, data, root) {
  var i1390 = root || request.c( 'TMPro.TMP_Style' )
  var i1391 = data
  i1390.m_Name = i1391[0]
  i1390.m_HashCode = i1391[1]
  i1390.m_OpeningDefinition = i1391[2]
  i1390.m_ClosingDefinition = i1391[3]
  i1390.m_OpeningTagArray = i1391[4]
  i1390.m_ClosingTagArray = i1391[5]
  return i1390
}

Deserializers["TMPro.TMP_Settings"] = function (request, data, root) {
  var i1392 = root || request.c( 'TMPro.TMP_Settings' )
  var i1393 = data
  i1392.assetVersion = i1393[0]
  i1392.m_TextWrappingMode = i1393[1]
  i1392.m_enableKerning = !!i1393[2]
  var i1395 = i1393[3]
  var i1394 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.TextCore.OTL_FeatureTag')))
  for(var i = 0; i < i1395.length; i += 1) {
    i1394.add(i1395[i + 0]);
  }
  i1392.m_ActiveFontFeatures = i1394
  i1392.m_enableExtraPadding = !!i1393[4]
  i1392.m_enableTintAllSprites = !!i1393[5]
  i1392.m_enableParseEscapeCharacters = !!i1393[6]
  i1392.m_EnableRaycastTarget = !!i1393[7]
  i1392.m_GetFontFeaturesAtRuntime = !!i1393[8]
  i1392.m_missingGlyphCharacter = i1393[9]
  i1392.m_ClearDynamicDataOnBuild = !!i1393[10]
  i1392.m_warningsDisabled = !!i1393[11]
  request.r(i1393[12], i1393[13], 0, i1392, 'm_defaultFontAsset')
  i1392.m_defaultFontAssetPath = i1393[14]
  i1392.m_defaultFontSize = i1393[15]
  i1392.m_defaultAutoSizeMinRatio = i1393[16]
  i1392.m_defaultAutoSizeMaxRatio = i1393[17]
  i1392.m_defaultTextMeshProTextContainerSize = new pc.Vec2( i1393[18], i1393[19] )
  i1392.m_defaultTextMeshProUITextContainerSize = new pc.Vec2( i1393[20], i1393[21] )
  i1392.m_autoSizeTextContainer = !!i1393[22]
  i1392.m_IsTextObjectScaleStatic = !!i1393[23]
  var i1397 = i1393[24]
  var i1396 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_FontAsset')))
  for(var i = 0; i < i1397.length; i += 2) {
  request.r(i1397[i + 0], i1397[i + 1], 1, i1396, '')
  }
  i1392.m_fallbackFontAssets = i1396
  i1392.m_matchMaterialPreset = !!i1393[25]
  i1392.m_HideSubTextObjects = !!i1393[26]
  request.r(i1393[27], i1393[28], 0, i1392, 'm_defaultSpriteAsset')
  i1392.m_defaultSpriteAssetPath = i1393[29]
  i1392.m_enableEmojiSupport = !!i1393[30]
  i1392.m_MissingCharacterSpriteUnicode = i1393[31]
  var i1399 = i1393[32]
  var i1398 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_Asset')))
  for(var i = 0; i < i1399.length; i += 2) {
  request.r(i1399[i + 0], i1399[i + 1], 1, i1398, '')
  }
  i1392.m_EmojiFallbackTextAssets = i1398
  i1392.m_defaultColorGradientPresetsPath = i1393[33]
  request.r(i1393[34], i1393[35], 0, i1392, 'm_defaultStyleSheet')
  i1392.m_StyleSheetsResourcePath = i1393[36]
  request.r(i1393[37], i1393[38], 0, i1392, 'm_leadingCharacters')
  request.r(i1393[39], i1393[40], 0, i1392, 'm_followingCharacters')
  i1392.m_UseModernHangulLineBreakingRules = !!i1393[41]
  return i1392
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Resources"] = function (request, data, root) {
  var i1402 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Resources' )
  var i1403 = data
  var i1405 = i1403[0]
  var i1404 = []
  for(var i = 0; i < i1405.length; i += 1) {
    i1404.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Resources+File', i1405[i + 0]) );
  }
  i1402.files = i1404
  i1402.componentToPrefabIds = i1403[1]
  return i1402
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Resources+File"] = function (request, data, root) {
  var i1408 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Resources+File' )
  var i1409 = data
  i1408.path = i1409[0]
  request.r(i1409[1], i1409[2], 0, i1408, 'unityObject')
  return i1408
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings"] = function (request, data, root) {
  var i1410 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings' )
  var i1411 = data
  var i1413 = i1411[0]
  var i1412 = []
  for(var i = 0; i < i1413.length; i += 1) {
    i1412.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+ScriptsExecutionOrder', i1413[i + 0]) );
  }
  i1410.scriptsExecutionOrder = i1412
  var i1415 = i1411[1]
  var i1414 = []
  for(var i = 0; i < i1415.length; i += 1) {
    i1414.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+SortingLayer', i1415[i + 0]) );
  }
  i1410.sortingLayers = i1414
  var i1417 = i1411[2]
  var i1416 = []
  for(var i = 0; i < i1417.length; i += 1) {
    i1416.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+CullingLayer', i1417[i + 0]) );
  }
  i1410.cullingLayers = i1416
  i1410.timeSettings = request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+TimeSettings', i1411[3], i1410.timeSettings)
  i1410.physicsSettings = request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings', i1411[4], i1410.physicsSettings)
  i1410.physics2DSettings = request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings', i1411[5], i1410.physics2DSettings)
  i1410.qualitySettings = request.d('Luna.Unity.DTO.UnityEngine.Assets.QualitySettings', i1411[6], i1410.qualitySettings)
  i1410.enableRealtimeShadows = !!i1411[7]
  i1410.enableAutoInstancing = !!i1411[8]
  i1410.enableStaticBatching = !!i1411[9]
  i1410.enableDynamicBatching = !!i1411[10]
  i1410.usePreservativeDynamicBatching = !!i1411[11]
  i1410.lightmapEncodingQuality = i1411[12]
  i1410.desiredColorSpace = i1411[13]
  var i1419 = i1411[14]
  var i1418 = []
  for(var i = 0; i < i1419.length; i += 1) {
    i1418.push( i1419[i + 0] );
  }
  i1410.allTags = i1418
  return i1410
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+ScriptsExecutionOrder"] = function (request, data, root) {
  var i1422 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+ScriptsExecutionOrder' )
  var i1423 = data
  i1422.name = i1423[0]
  i1422.value = i1423[1]
  return i1422
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+SortingLayer"] = function (request, data, root) {
  var i1426 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+SortingLayer' )
  var i1427 = data
  i1426.id = i1427[0]
  i1426.name = i1427[1]
  i1426.value = i1427[2]
  return i1426
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+CullingLayer"] = function (request, data, root) {
  var i1430 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+CullingLayer' )
  var i1431 = data
  i1430.id = i1431[0]
  i1430.name = i1431[1]
  return i1430
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+TimeSettings"] = function (request, data, root) {
  var i1432 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+TimeSettings' )
  var i1433 = data
  i1432.fixedDeltaTime = i1433[0]
  i1432.maximumDeltaTime = i1433[1]
  i1432.timeScale = i1433[2]
  i1432.maximumParticleTimestep = i1433[3]
  return i1432
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings"] = function (request, data, root) {
  var i1434 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings' )
  var i1435 = data
  i1434.gravity = new pc.Vec3( i1435[0], i1435[1], i1435[2] )
  i1434.defaultSolverIterations = i1435[3]
  i1434.bounceThreshold = i1435[4]
  i1434.autoSyncTransforms = !!i1435[5]
  i1434.autoSimulation = !!i1435[6]
  var i1437 = i1435[7]
  var i1436 = []
  for(var i = 0; i < i1437.length; i += 1) {
    i1436.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings+CollisionMask', i1437[i + 0]) );
  }
  i1434.collisionMatrix = i1436
  return i1434
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings+CollisionMask"] = function (request, data, root) {
  var i1440 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings+CollisionMask' )
  var i1441 = data
  i1440.enabled = !!i1441[0]
  i1440.layerId = i1441[1]
  i1440.otherLayerId = i1441[2]
  return i1440
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings"] = function (request, data, root) {
  var i1442 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings' )
  var i1443 = data
  request.r(i1443[0], i1443[1], 0, i1442, 'material')
  i1442.gravity = new pc.Vec2( i1443[2], i1443[3] )
  i1442.positionIterations = i1443[4]
  i1442.velocityIterations = i1443[5]
  i1442.velocityThreshold = i1443[6]
  i1442.maxLinearCorrection = i1443[7]
  i1442.maxAngularCorrection = i1443[8]
  i1442.maxTranslationSpeed = i1443[9]
  i1442.maxRotationSpeed = i1443[10]
  i1442.baumgarteScale = i1443[11]
  i1442.baumgarteTOIScale = i1443[12]
  i1442.timeToSleep = i1443[13]
  i1442.linearSleepTolerance = i1443[14]
  i1442.angularSleepTolerance = i1443[15]
  i1442.defaultContactOffset = i1443[16]
  i1442.autoSimulation = !!i1443[17]
  i1442.queriesHitTriggers = !!i1443[18]
  i1442.queriesStartInColliders = !!i1443[19]
  i1442.callbacksOnDisable = !!i1443[20]
  i1442.reuseCollisionCallbacks = !!i1443[21]
  i1442.autoSyncTransforms = !!i1443[22]
  var i1445 = i1443[23]
  var i1444 = []
  for(var i = 0; i < i1445.length; i += 1) {
    i1444.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings+CollisionMask', i1445[i + 0]) );
  }
  i1442.collisionMatrix = i1444
  return i1442
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings+CollisionMask"] = function (request, data, root) {
  var i1448 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings+CollisionMask' )
  var i1449 = data
  i1448.enabled = !!i1449[0]
  i1448.layerId = i1449[1]
  i1448.otherLayerId = i1449[2]
  return i1448
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.QualitySettings"] = function (request, data, root) {
  var i1450 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.QualitySettings' )
  var i1451 = data
  var i1453 = i1451[0]
  var i1452 = []
  for(var i = 0; i < i1453.length; i += 1) {
    i1452.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.QualitySettings', i1453[i + 0]) );
  }
  i1450.qualityLevels = i1452
  var i1455 = i1451[1]
  var i1454 = []
  for(var i = 0; i < i1455.length; i += 1) {
    i1454.push( i1455[i + 0] );
  }
  i1450.names = i1454
  i1450.shadows = i1451[2]
  i1450.anisotropicFiltering = i1451[3]
  i1450.antiAliasing = i1451[4]
  i1450.lodBias = i1451[5]
  i1450.shadowCascades = i1451[6]
  i1450.shadowDistance = i1451[7]
  i1450.shadowmaskMode = i1451[8]
  i1450.shadowProjection = i1451[9]
  i1450.shadowResolution = i1451[10]
  i1450.softParticles = !!i1451[11]
  i1450.softVegetation = !!i1451[12]
  i1450.activeColorSpace = i1451[13]
  i1450.desiredColorSpace = i1451[14]
  i1450.masterTextureLimit = i1451[15]
  i1450.maxQueuedFrames = i1451[16]
  i1450.particleRaycastBudget = i1451[17]
  i1450.pixelLightCount = i1451[18]
  i1450.realtimeReflectionProbes = !!i1451[19]
  i1450.shadowCascade2Split = i1451[20]
  i1450.shadowCascade4Split = new pc.Vec3( i1451[21], i1451[22], i1451[23] )
  i1450.streamingMipmapsActive = !!i1451[24]
  i1450.vSyncCount = i1451[25]
  i1450.asyncUploadBufferSize = i1451[26]
  i1450.asyncUploadTimeSlice = i1451[27]
  i1450.billboardsFaceCameraPosition = !!i1451[28]
  i1450.shadowNearPlaneOffset = i1451[29]
  i1450.streamingMipmapsMemoryBudget = i1451[30]
  i1450.maximumLODLevel = i1451[31]
  i1450.streamingMipmapsAddAllCameras = !!i1451[32]
  i1450.streamingMipmapsMaxLevelReduction = i1451[33]
  i1450.streamingMipmapsRenderersPerFrame = i1451[34]
  i1450.resolutionScalingFixedDPIFactor = i1451[35]
  i1450.streamingMipmapsMaxFileIORequests = i1451[36]
  i1450.currentQualityLevel = i1451[37]
  return i1450
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.RenderObjects+RenderObjectsSettings"] = function (request, data, root) {
  var i1458 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.RenderObjects+RenderObjectsSettings' )
  var i1459 = data
  i1458.Event = request.d('Luna.Unity.DTO.UnityEngine.Assets.EnumDescription', i1459[0], i1458.Event)
  i1458.filterSettings = request.d('Luna.Unity.DTO.UnityEngine.Assets.RenderObjects+FilterSettings', i1459[1], i1458.filterSettings)
  i1458.overrideMaterialId = i1459[2]
  i1458.overrideMaterialPassIndex = i1459[3]
  i1458.overrideShaderId = i1459[4]
  i1458.overrideShaderPassIndex = i1459[5]
  i1458.overrideMode = request.d('Luna.Unity.DTO.UnityEngine.Assets.EnumDescription', i1459[6], i1458.overrideMode)
  i1458.overrideDepthState = !!i1459[7]
  i1458.depthCompareFunction = request.d('Luna.Unity.DTO.UnityEngine.Assets.EnumDescription', i1459[8], i1458.depthCompareFunction)
  i1458.enableWrite = !!i1459[9]
  i1458.stencilSettings = request.d('Luna.Unity.DTO.UnityEngine.Assets.StencilStateData', i1459[10], i1458.stencilSettings)
  i1458.cameraSettings = request.d('Luna.Unity.DTO.UnityEngine.Assets.RenderObjects+CustomCameraSettings', i1459[11], i1458.cameraSettings)
  return i1458
}

Deserializers["TMPro.GlyphValueRecord_Legacy"] = function (request, data, root) {
  var i1460 = root || request.c( 'TMPro.GlyphValueRecord_Legacy' )
  var i1461 = data
  i1460.xPlacement = i1461[0]
  i1460.yPlacement = i1461[1]
  i1460.xAdvance = i1461[2]
  i1460.yAdvance = i1461[3]
  return i1460
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.EnumDescription"] = function (request, data, root) {
  var i1462 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.EnumDescription' )
  var i1463 = data
  i1462.Value = i1463[0]
  return i1462
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.RenderObjects+FilterSettings"] = function (request, data, root) {
  var i1464 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.RenderObjects+FilterSettings' )
  var i1465 = data
  i1464.RenderQueueType = request.d('Luna.Unity.DTO.UnityEngine.Assets.EnumDescription', i1465[0], i1464.RenderQueueType)
  i1464.LayerMask = i1465[1]
  var i1467 = i1465[2]
  var i1466 = []
  for(var i = 0; i < i1467.length; i += 1) {
    i1466.push( i1467[i + 0] );
  }
  i1464.PassNames = i1466
  return i1464
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.StencilStateData"] = function (request, data, root) {
  var i1468 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.StencilStateData' )
  var i1469 = data
  i1468.overrideStencilState = !!i1469[0]
  i1468.stencilReference = i1469[1]
  i1468.stencilCompareFunctionValue = request.d('Luna.Unity.DTO.UnityEngine.Assets.EnumDescription', i1469[2], i1468.stencilCompareFunctionValue)
  i1468.passOperationValue = request.d('Luna.Unity.DTO.UnityEngine.Assets.EnumDescription', i1469[3], i1468.passOperationValue)
  i1468.failOperationValue = request.d('Luna.Unity.DTO.UnityEngine.Assets.EnumDescription', i1469[4], i1468.failOperationValue)
  i1468.zFailOperationValue = request.d('Luna.Unity.DTO.UnityEngine.Assets.EnumDescription', i1469[5], i1468.zFailOperationValue)
  return i1468
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.RenderObjects+CustomCameraSettings"] = function (request, data, root) {
  var i1470 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.RenderObjects+CustomCameraSettings' )
  var i1471 = data
  i1470.overrideCamera = !!i1471[0]
  i1470.restoreCamera = !!i1471[1]
  i1470.offset = new pc.Vec4( i1471[2], i1471[3], i1471[4], i1471[5] )
  i1470.cameraFieldOfView = i1471[6]
  return i1470
}

Deserializers.fields = {"Luna.Unity.DTO.UnityEngine.Assets.Material":{"name":0,"shader":1,"renderQueue":3,"enableInstancing":4,"floatParameters":5,"colorParameters":6,"vectorParameters":7,"textureParameters":8,"materialFlags":9},"Luna.Unity.DTO.UnityEngine.Assets.Material+FloatParameter":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.Material+ColorParameter":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.Material+VectorParameter":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.Material+TextureParameter":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.Material+MaterialFlag":{"name":0,"enabled":1},"Luna.Unity.DTO.UnityEngine.Textures.Texture2D":{"name":0,"width":1,"height":2,"mipmapCount":3,"anisoLevel":4,"filterMode":5,"hdr":6,"format":7,"wrapMode":8,"alphaIsTransparency":9,"alphaSource":10,"graphicsFormat":11,"sRGBTexture":12,"desiredColorSpace":13,"wrapU":14,"wrapV":15},"Luna.Unity.DTO.UnityEngine.Components.Transform":{"position":0,"scale":3,"rotation":6},"Luna.Unity.DTO.UnityEngine.Components.SpriteRenderer":{"color":0,"sprite":4,"flipX":6,"flipY":7,"drawMode":8,"size":9,"tileMode":11,"adaptiveModeThreshold":12,"maskInteraction":13,"spriteSortPoint":14,"enabled":15,"sharedMaterial":16,"sharedMaterials":18,"receiveShadows":19,"shadowCastingMode":20,"sortingLayerID":21,"sortingOrder":22,"lightmapIndex":23,"lightmapSceneIndex":24,"lightmapScaleOffset":25,"lightProbeUsage":29,"reflectionProbeUsage":30},"Luna.Unity.DTO.UnityEngine.Components.SortingGroup":{"sortingLayerIndex":0,"sortingOrder":1,"sortingLayerName":2,"enabled":3},"Luna.Unity.DTO.UnityEngine.Scene.GameObject":{"name":0,"tagId":1,"enabled":2,"isStatic":3,"layer":4},"Luna.Unity.DTO.UnityEngine.Components.ParticleSystemRenderer":{"mesh":0,"meshCount":2,"activeVertexStreamsCount":3,"alignment":4,"renderMode":5,"sortMode":6,"lengthScale":7,"velocityScale":8,"cameraVelocityScale":9,"normalDirection":10,"sortingFudge":11,"minParticleSize":12,"maxParticleSize":13,"pivot":14,"trailMaterial":17,"applyActiveColorSpace":19,"enabled":20,"sharedMaterial":21,"sharedMaterials":23,"receiveShadows":24,"shadowCastingMode":25,"sortingLayerID":26,"sortingOrder":27,"lightmapIndex":28,"lightmapSceneIndex":29,"lightmapScaleOffset":30,"lightProbeUsage":34,"reflectionProbeUsage":35},"Luna.Unity.DTO.UnityEngine.Components.ParticleSystem":{"main":0,"colorBySpeed":1,"colorOverLifetime":2,"emission":3,"rotationBySpeed":4,"rotationOverLifetime":5,"shape":6,"sizeBySpeed":7,"sizeOverLifetime":8,"textureSheetAnimation":9,"velocityOverLifetime":10,"noise":11,"inheritVelocity":12,"forceOverLifetime":13,"limitVelocityOverLifetime":14,"useAutoRandomSeed":15,"randomSeed":16},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.MainModule":{"duration":0,"loop":1,"prewarm":2,"startDelay":3,"startLifetime":4,"startSpeed":5,"startSize3D":6,"startSizeX":7,"startSizeY":8,"startSizeZ":9,"startRotation3D":10,"startRotationX":11,"startRotationY":12,"startRotationZ":13,"startColor":14,"gravityModifier":15,"simulationSpace":16,"customSimulationSpace":17,"simulationSpeed":19,"useUnscaledTime":20,"scalingMode":21,"playOnAwake":22,"maxParticles":23,"emitterVelocityMode":24,"stopAction":25},"Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve":{"mode":0,"curveMin":1,"curveMax":2,"curveMultiplier":3,"constantMin":4,"constantMax":5},"Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxGradient":{"mode":0,"gradientMin":1,"gradientMax":2,"colorMin":3,"colorMax":7},"Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Gradient":{"mode":0,"colorKeys":1,"alphaKeys":2},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ColorBySpeedModule":{"enabled":0,"color":1,"range":2},"Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Data.GradientColorKey":{"color":0,"time":4},"Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Data.GradientAlphaKey":{"alpha":0,"time":1},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ColorOverLifetimeModule":{"enabled":0,"color":1},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.EmissionModule":{"enabled":0,"rateOverTime":1,"rateOverDistance":2,"bursts":3},"Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Burst":{"count":0,"cycleCount":1,"minCount":2,"maxCount":3,"repeatInterval":4,"time":5},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.RotationBySpeedModule":{"enabled":0,"x":1,"y":2,"z":3,"separateAxes":4,"range":5},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.RotationOverLifetimeModule":{"enabled":0,"x":1,"y":2,"z":3,"separateAxes":4},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ShapeModule":{"enabled":0,"shapeType":1,"randomDirectionAmount":2,"sphericalDirectionAmount":3,"randomPositionAmount":4,"alignToDirection":5,"radius":6,"radiusMode":7,"radiusSpread":8,"radiusSpeed":9,"radiusThickness":10,"angle":11,"length":12,"boxThickness":13,"meshShapeType":16,"mesh":17,"meshRenderer":19,"skinnedMeshRenderer":21,"useMeshMaterialIndex":23,"meshMaterialIndex":24,"useMeshColors":25,"normalOffset":26,"arc":27,"arcMode":28,"arcSpread":29,"arcSpeed":30,"donutRadius":31,"position":32,"rotation":35,"scale":38},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.SizeBySpeedModule":{"enabled":0,"x":1,"y":2,"z":3,"separateAxes":4,"range":5},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.SizeOverLifetimeModule":{"enabled":0,"x":1,"y":2,"z":3,"separateAxes":4},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.TextureSheetAnimationModule":{"enabled":0,"mode":1,"animation":2,"numTilesX":3,"numTilesY":4,"useRandomRow":5,"frameOverTime":6,"startFrame":7,"cycleCount":8,"rowIndex":9,"flipU":10,"flipV":11,"spriteCount":12,"sprites":13},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.VelocityOverLifetimeModule":{"enabled":0,"x":1,"y":2,"z":3,"radial":4,"speedModifier":5,"space":6,"orbitalX":7,"orbitalY":8,"orbitalZ":9,"orbitalOffsetX":10,"orbitalOffsetY":11,"orbitalOffsetZ":12},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.NoiseModule":{"enabled":0,"separateAxes":1,"strengthX":2,"strengthY":3,"strengthZ":4,"frequency":5,"damping":6,"octaveCount":7,"octaveMultiplier":8,"octaveScale":9,"quality":10,"scrollSpeed":11,"scrollSpeedMultiplier":12,"remapEnabled":13,"remapX":14,"remapY":15,"remapZ":16,"positionAmount":17,"rotationAmount":18,"sizeAmount":19},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.InheritVelocityModule":{"enabled":0,"mode":1,"curve":2},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ForceOverLifetimeModule":{"enabled":0,"x":1,"y":2,"z":3,"space":4,"randomized":5},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.LimitVelocityOverLifetimeModule":{"enabled":0,"limit":1,"limitX":2,"limitY":3,"limitZ":4,"dampen":5,"separateAxes":6,"space":7,"drag":8,"multiplyDragByParticleSize":9,"multiplyDragByParticleVelocity":10},"Luna.Unity.DTO.UnityEngine.Components.BoxCollider2D":{"usedByComposite":0,"autoTiling":1,"size":2,"edgeRadius":4,"enabled":5,"isTrigger":6,"usedByEffector":7,"density":8,"offset":9,"material":11},"Luna.Unity.DTO.UnityEngine.Textures.Cubemap":{"name":0,"atlasId":1,"mipmapCount":2,"hdr":3,"size":4,"anisoLevel":5,"filterMode":6,"rects":7,"wrapU":8,"wrapV":9},"Luna.Unity.DTO.UnityEngine.Scene.Scene":{"name":0,"index":1,"startup":2},"Luna.Unity.DTO.UnityEngine.Components.Camera":{"aspect":0,"orthographic":1,"orthographicSize":2,"backgroundColor":3,"nearClipPlane":7,"farClipPlane":8,"fieldOfView":9,"depth":10,"clearFlags":11,"cullingMask":12,"rect":13,"targetTexture":14,"usePhysicalProperties":16,"focalLength":17,"sensorSize":18,"lensShift":20,"gateFit":22,"commandBufferCount":23,"cameraType":24,"enabled":25},"Luna.Unity.DTO.UnityEngine.Components.BoxCollider":{"center":0,"size":3,"enabled":6,"isTrigger":7,"material":8},"Luna.Unity.DTO.UnityEngine.Components.RectTransform":{"pivot":0,"anchorMin":2,"anchorMax":4,"sizeDelta":6,"anchoredPosition3D":8,"rotation":11,"scale":15},"Luna.Unity.DTO.UnityEngine.Components.Canvas":{"planeDistance":0,"referencePixelsPerUnit":1,"isFallbackOverlay":2,"renderMode":3,"renderOrder":4,"sortingLayerName":5,"sortingOrder":6,"scaleFactor":7,"worldCamera":8,"overrideSorting":10,"pixelPerfect":11,"targetDisplay":12,"overridePixelPerfect":13,"enabled":14},"Luna.Unity.DTO.UnityEngine.Components.CanvasRenderer":{"cullTransparentMesh":0},"Luna.Unity.DTO.UnityEngine.Components.AudioSource":{"clip":0,"outputAudioMixerGroup":2,"playOnAwake":4,"loop":5,"time":6,"volume":7,"pitch":8,"enabled":9},"Luna.Unity.DTO.UnityEngine.Assets.RenderSettings":{"ambientIntensity":0,"reflectionIntensity":1,"ambientMode":2,"ambientLight":3,"ambientSkyColor":7,"ambientGroundColor":11,"ambientEquatorColor":15,"fogColor":19,"fogEndDistance":23,"fogStartDistance":24,"fogDensity":25,"fog":26,"skybox":27,"fogMode":29,"lightmaps":30,"lightProbes":31,"lightmapsMode":32,"mixedBakeMode":33,"environmentLightingMode":34,"ambientProbe":35,"customReflection":36,"defaultReflection":38,"defaultReflectionMode":40,"defaultReflectionResolution":41,"sunLightObjectId":42,"pixelLightCount":43,"defaultReflectionHDR":44,"hasLightDataAsset":45,"hasManualGenerate":46},"Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+Lightmap":{"lightmapColor":0,"lightmapDirection":2,"shadowMask":4},"Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+LightProbes":{"bakedProbes":0,"positions":1,"hullRays":2,"tetrahedra":3,"neighbours":4,"matrices":5},"Luna.Unity.DTO.UnityEngine.Assets.UniversalRenderPipelineAsset":{"AdditionalLightsRenderingMode":0,"LightRenderingMode":1,"MainLightRenderingModeValue":2,"SupportsMainLightShadows":3,"MixedLightingSupported":4,"MainLightShadowmapResolutionValue":5,"SupportsSoftShadows":6,"SoftShadowQualityValue":7,"ShadowDistance":8,"ShadowCascadeCount":9,"Cascade2Split":10,"Cascade3Split":11,"Cascade4Split":13,"CascadeBorder":16,"ShadowDepthBias":17,"ShadowNormalBias":18,"RequireDepthTexture":19,"RequireOpaqueTexture":20,"scriptableRendererData":21},"Luna.Unity.DTO.UnityEngine.Assets.LightRenderingMode":{"Disabled":0,"PerVertex":1,"PerPixel":2},"Luna.Unity.DTO.UnityEngine.Assets.ScriptableRendererData":{"opaqueLayerMask":0,"transparentLayerMask":1,"RenderObjectsFeatures":2,"name":3},"Luna.Unity.DTO.UnityEngine.Assets.RenderObjects":{"settings":0,"name":1,"typeName":2},"Luna.Unity.DTO.UnityEngine.Assets.Shader":{"ShaderCompilationErrors":0,"name":1,"guid":2,"shaderDefinedKeywords":3,"passes":4,"usePasses":5,"defaultParameterValues":6,"unityFallbackShader":7,"readDepth":9,"hasDepthOnlyPass":10,"isCreatedByShaderGraph":11,"disableBatching":12,"compiled":13},"Luna.Unity.DTO.UnityEngine.Assets.Shader+ShaderCompilationError":{"shaderName":0,"errorMessage":1},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass":{"id":0,"subShaderIndex":1,"name":2,"passType":3,"grabPassTextureName":4,"usePass":5,"zTest":6,"zWrite":7,"culling":8,"blending":9,"alphaBlending":10,"colorWriteMask":11,"offsetUnits":12,"offsetFactor":13,"stencilRef":14,"stencilReadMask":15,"stencilWriteMask":16,"stencilOp":17,"stencilOpFront":18,"stencilOpBack":19,"tags":20,"passDefinedKeywords":21,"passDefinedKeywordGroups":22,"variants":23,"excludedVariants":24,"hasDepthReader":25},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value":{"val":0,"name":1},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Blending":{"src":0,"dst":1,"op":2},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp":{"pass":0,"fail":1,"zFail":2,"comp":3},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Tag":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+KeywordGroup":{"keywords":0,"hasDiscard":1},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Variant":{"passId":0,"subShaderIndex":1,"keywords":2,"vertexProgram":3,"fragmentProgram":4,"exportedForWebGl2":5,"readDepth":6},"Luna.Unity.DTO.UnityEngine.Assets.Shader+UsePass":{"shader":0,"pass":2},"Luna.Unity.DTO.UnityEngine.Assets.Shader+DefaultParameterValue":{"name":0,"type":1,"value":2,"textureValue":6,"shaderPropertyFlag":7},"Luna.Unity.DTO.UnityEngine.Textures.Sprite":{"name":0,"texture":1,"aabb":3,"vertices":4,"triangles":5,"textureRect":6,"packedRect":10,"border":14,"transparency":18,"bounds":19,"pixelsPerUnit":20,"textureWidth":21,"textureHeight":22,"nativeSize":23,"pivot":25,"textureRectOffset":27},"Luna.Unity.DTO.UnityEngine.Assets.AudioClip":{"name":0},"Luna.Unity.DTO.UnityEngine.Assets.Font":{"name":0,"ascent":1,"originalLineHeight":2,"fontSize":3,"characterInfo":4,"texture":5,"originalFontSize":7},"Luna.Unity.DTO.UnityEngine.Assets.Font+CharacterInfo":{"index":0,"advance":1,"bearing":2,"glyphWidth":3,"glyphHeight":4,"minX":5,"maxX":6,"minY":7,"maxY":8,"uvBottomLeftX":9,"uvBottomLeftY":10,"uvBottomRightX":11,"uvBottomRightY":12,"uvTopLeftX":13,"uvTopLeftY":14,"uvTopRightX":15,"uvTopRightY":16},"Luna.Unity.DTO.UnityEngine.Assets.TextAsset":{"name":0,"bytes64":1,"data":2},"Luna.Unity.DTO.UnityEngine.Assets.Resources":{"files":0,"componentToPrefabIds":1},"Luna.Unity.DTO.UnityEngine.Assets.Resources+File":{"path":0,"unityObject":1},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings":{"scriptsExecutionOrder":0,"sortingLayers":1,"cullingLayers":2,"timeSettings":3,"physicsSettings":4,"physics2DSettings":5,"qualitySettings":6,"enableRealtimeShadows":7,"enableAutoInstancing":8,"enableStaticBatching":9,"enableDynamicBatching":10,"usePreservativeDynamicBatching":11,"lightmapEncodingQuality":12,"desiredColorSpace":13,"allTags":14},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+ScriptsExecutionOrder":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+SortingLayer":{"id":0,"name":1,"value":2},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+CullingLayer":{"id":0,"name":1},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+TimeSettings":{"fixedDeltaTime":0,"maximumDeltaTime":1,"timeScale":2,"maximumParticleTimestep":3},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings":{"gravity":0,"defaultSolverIterations":3,"bounceThreshold":4,"autoSyncTransforms":5,"autoSimulation":6,"collisionMatrix":7},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings+CollisionMask":{"enabled":0,"layerId":1,"otherLayerId":2},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings":{"material":0,"gravity":2,"positionIterations":4,"velocityIterations":5,"velocityThreshold":6,"maxLinearCorrection":7,"maxAngularCorrection":8,"maxTranslationSpeed":9,"maxRotationSpeed":10,"baumgarteScale":11,"baumgarteTOIScale":12,"timeToSleep":13,"linearSleepTolerance":14,"angularSleepTolerance":15,"defaultContactOffset":16,"autoSimulation":17,"queriesHitTriggers":18,"queriesStartInColliders":19,"callbacksOnDisable":20,"reuseCollisionCallbacks":21,"autoSyncTransforms":22,"collisionMatrix":23},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings+CollisionMask":{"enabled":0,"layerId":1,"otherLayerId":2},"Luna.Unity.DTO.UnityEngine.Assets.QualitySettings":{"qualityLevels":0,"names":1,"shadows":2,"anisotropicFiltering":3,"antiAliasing":4,"lodBias":5,"shadowCascades":6,"shadowDistance":7,"shadowmaskMode":8,"shadowProjection":9,"shadowResolution":10,"softParticles":11,"softVegetation":12,"activeColorSpace":13,"desiredColorSpace":14,"masterTextureLimit":15,"maxQueuedFrames":16,"particleRaycastBudget":17,"pixelLightCount":18,"realtimeReflectionProbes":19,"shadowCascade2Split":20,"shadowCascade4Split":21,"streamingMipmapsActive":24,"vSyncCount":25,"asyncUploadBufferSize":26,"asyncUploadTimeSlice":27,"billboardsFaceCameraPosition":28,"shadowNearPlaneOffset":29,"streamingMipmapsMemoryBudget":30,"maximumLODLevel":31,"streamingMipmapsAddAllCameras":32,"streamingMipmapsMaxLevelReduction":33,"streamingMipmapsRenderersPerFrame":34,"resolutionScalingFixedDPIFactor":35,"streamingMipmapsMaxFileIORequests":36,"currentQualityLevel":37},"Luna.Unity.DTO.UnityEngine.Assets.RenderObjects+RenderObjectsSettings":{"Event":0,"filterSettings":1,"overrideMaterialId":2,"overrideMaterialPassIndex":3,"overrideShaderId":4,"overrideShaderPassIndex":5,"overrideMode":6,"overrideDepthState":7,"depthCompareFunction":8,"enableWrite":9,"stencilSettings":10,"cameraSettings":11},"Luna.Unity.DTO.UnityEngine.Assets.EnumDescription":{"Value":0},"Luna.Unity.DTO.UnityEngine.Assets.RenderObjects+FilterSettings":{"RenderQueueType":0,"LayerMask":1,"PassNames":2},"Luna.Unity.DTO.UnityEngine.Assets.StencilStateData":{"overrideStencilState":0,"stencilReference":1,"stencilCompareFunctionValue":2,"passOperationValue":3,"failOperationValue":4,"zFailOperationValue":5},"Luna.Unity.DTO.UnityEngine.Assets.RenderObjects+CustomCameraSettings":{"overrideCamera":0,"restoreCamera":1,"offset":2,"cameraFieldOfView":6}}

Deserializers.requiredComponents = {"104":[105],"106":[105],"107":[105],"108":[105],"109":[105],"110":[105],"111":[112],"113":[19],"114":[115],"116":[115],"117":[115],"118":[115],"119":[115],"120":[115],"121":[122],"123":[122],"124":[122],"125":[122],"126":[122],"127":[122],"128":[122],"129":[122],"130":[122],"131":[122],"132":[122],"133":[122],"134":[122],"135":[19],"136":[137],"138":[139],"140":[139],"27":[26],"11":[141],"142":[24],"143":[27],"77":[26],"144":[19],"145":[19],"146":[147],"148":[26],"149":[30,26],"150":[137],"151":[30,26],"152":[26],"153":[26],"154":[137,26],"33":[26,30],"155":[156],"157":[156],"158":[156],"159":[26],"160":[26],"29":[27],"31":[30,26],"38":[26],"28":[27],"58":[26],"161":[26],"84":[26],"162":[26],"63":[26],"163":[26],"57":[26],"66":[26],"164":[26],"165":[30,26],"166":[26],"62":[26],"65":[26],"167":[26],"61":[30,26],"70":[26],"168":[24],"169":[24],"25":[24],"170":[24],"171":[19],"172":[19]}

Deserializers.types = ["UnityEngine.Shader","UnityEngine.Transform","UnityEngine.SpriteRenderer","UnityEngine.Sprite","UnityEngine.Material","UnityEngine.MonoBehaviour","HighlightedZone","UnityEngine.Rendering.SortingGroup","UnityEngine.Texture2D","UnityEngine.ParticleSystemRenderer","UnityEngine.ParticleSystem","FogObject","DragObject","UnityEngine.GameObject","UnityEngine.BoxCollider2D","EggBasket","FlyableMergeObject","DecorationObject","GridCell","UnityEngine.Camera","UnityEngine.AudioListener","CameraController","UnityEngine.BoxCollider","UnityEngine.EventSystems.UIBehaviour","UnityEngine.EventSystems.EventSystem","UnityEngine.EventSystems.StandaloneInputModule","UnityEngine.RectTransform","UnityEngine.Canvas","UnityEngine.UI.CanvasScaler","UnityEngine.UI.GraphicRaycaster","UnityEngine.CanvasRenderer","UnityEngine.UI.Image","UnityEngine.UI.Button","TMPro.TextMeshProUGUI","TMPro.TMP_FontAsset","TutorialHandPointer","DinoCarousel","PlayNowButton","UnityEngine.UI.AspectRatioFitter","TutorialHand","ObjectManager","FogManager","MapFogLayoutManager","PointsManager","MapObjectLayoutManager","MainSystem","CustomGridShape","FlyingObjectsManager","DragManager","DinoSelectionManager","FlyingDragManager","ObjectSet","AudioSystem","UnityEngine.AudioSource","UnityEngine.AudioClip","UnityEngine.Cubemap","UnityEngine.Rendering.UI.DebugUIHandlerCanvas","UnityEngine.UI.VerticalLayoutGroup","UnityEngine.UI.ContentSizeFitter","UnityEngine.Rendering.UI.DebugUIHandlerContainer","UnityEngine.Rendering.UI.DebugUIHandlerPanel","UnityEngine.UI.Text","UnityEngine.UI.ScrollRect","UnityEngine.UI.LayoutElement","UnityEngine.Font","UnityEngine.UI.Scrollbar","UnityEngine.UI.Mask","UnityEngine.EventSystems.EventTrigger","UnityEngine.Rendering.UI.DebugUIHandlerValue","UnityEngine.Rendering.UI.DebugUIHandlerToggle","UnityEngine.UI.Toggle","UnityEngine.Rendering.UI.DebugUIHandlerIntField","UnityEngine.Rendering.UI.DebugUIHandlerUIntField","UnityEngine.Rendering.UI.DebugUIHandlerFloatField","UnityEngine.Rendering.UI.DebugUIHandlerEnumField","UnityEngine.Rendering.UI.DebugUIHandlerButton","UnityEngine.Rendering.UI.DebugUIHandlerFoldout","UnityEngine.Rendering.UI.UIFoldout","UnityEngine.Rendering.UI.DebugUIHandlerColor","UnityEngine.Rendering.UI.DebugUIHandlerIndirectFloatField","UnityEngine.Rendering.UI.DebugUIHandlerVector2","UnityEngine.Rendering.UI.DebugUIHandlerVector3","UnityEngine.Rendering.UI.DebugUIHandlerVector4","UnityEngine.Rendering.UI.DebugUIHandlerVBox","UnityEngine.UI.HorizontalLayoutGroup","UnityEngine.Rendering.UI.DebugUIHandlerHBox","UnityEngine.Rendering.UI.DebugUIHandlerGroup","UnityEngine.Rendering.UI.DebugUIHandlerBitField","UnityEngine.Rendering.UI.DebugUIHandlerIndirectToggle","UnityEngine.Rendering.UI.DebugUIHandlerToggleHistory","UnityEngine.Rendering.UI.DebugUIHandlerEnumHistory","UnityEngine.Rendering.UI.DebugUIHandlerRow","UnityEngine.Rendering.UI.DebugUIHandlerMessageBox","UnityEngine.Rendering.UI.DebugUIHandlerProgressBar","UnityEngine.Rendering.UI.DebugUIHandlerValueTuple","UnityEngine.Rendering.UI.DebugUIHandlerObject","UnityEngine.Rendering.UI.DebugUIHandlerObjectList","UnityEngine.Rendering.UI.DebugUIHandlerObjectPopupField","UnityEngine.Rendering.UI.DebugUIHandlerRenderingLayerField","UnityEngine.Rendering.UI.DebugUIHandlerPersistentCanvas","TMPro.TMP_SpriteAsset","TMPro.TMP_StyleSheet","TMPro.TMP_Settings","UnityEngine.TextAsset","UnityEngine.AudioLowPassFilter","UnityEngine.AudioBehaviour","UnityEngine.AudioHighPassFilter","UnityEngine.AudioReverbFilter","UnityEngine.AudioDistortionFilter","UnityEngine.AudioEchoFilter","UnityEngine.AudioChorusFilter","UnityEngine.Cloth","UnityEngine.SkinnedMeshRenderer","UnityEngine.FlareLayer","UnityEngine.CharacterJoint","UnityEngine.Rigidbody","UnityEngine.ConfigurableJoint","UnityEngine.ConstantForce","UnityEngine.FixedJoint","UnityEngine.HingeJoint","UnityEngine.SpringJoint","UnityEngine.CompositeCollider2D","UnityEngine.Rigidbody2D","UnityEngine.Joint2D","UnityEngine.AnchoredJoint2D","UnityEngine.SpringJoint2D","UnityEngine.DistanceJoint2D","UnityEngine.FrictionJoint2D","UnityEngine.HingeJoint2D","UnityEngine.RelativeJoint2D","UnityEngine.SliderJoint2D","UnityEngine.TargetJoint2D","UnityEngine.FixedJoint2D","UnityEngine.WheelJoint2D","UnityEngine.ConstantForce2D","UnityEngine.StreamingController","UnityEngine.TextMesh","UnityEngine.MeshRenderer","UnityEngine.Tilemaps.TilemapRenderer","UnityEngine.Tilemaps.Tilemap","UnityEngine.Tilemaps.TilemapCollider2D","UnityEngine.Renderer","UnityEngine.InputSystem.UI.InputSystemUIInputModule","UnityEngine.InputSystem.UI.TrackedDeviceRaycaster","UnityEngine.Rendering.Universal.PixelPerfectCamera","UnityEngine.Rendering.Universal.UniversalAdditionalCameraData","UnityEngine.Rendering.Universal.UniversalAdditionalLightData","UnityEngine.Light","TMPro.TMP_Dropdown","TMPro.TMP_SelectionCaret","TMPro.TMP_SubMesh","TMPro.TMP_SubMeshUI","TMPro.TMP_Text","TMPro.TextContainer","TMPro.TextMeshPro","Unity.VisualScripting.SceneVariables","Unity.VisualScripting.Variables","Unity.VisualScripting.ScriptMachine","Unity.VisualScripting.StateMachine","UnityEngine.UI.Dropdown","UnityEngine.UI.Graphic","UnityEngine.UI.GridLayoutGroup","UnityEngine.UI.HorizontalOrVerticalLayoutGroup","UnityEngine.UI.LayoutGroup","UnityEngine.UI.MaskableGraphic","UnityEngine.UI.RawImage","UnityEngine.UI.RectMask2D","UnityEngine.UI.Slider","UnityEngine.EventSystems.BaseInputModule","UnityEngine.EventSystems.PointerInputModule","UnityEngine.EventSystems.TouchInputModule","UnityEngine.EventSystems.Physics2DRaycaster","UnityEngine.EventSystems.PhysicsRaycaster"]

Deserializers.unityVersion = "6000.0.84f1";

Deserializers.productName = "Dino Merge";

Deserializers.lunaInitializationTime = "09/17/2026 09:47:36";

Deserializers.lunaDaysRunning = "0.2";

Deserializers.lunaVersion = "7.2.0";

Deserializers.lunaSHA = "ea08d29afe2968efcb8d91d5624f033c6485cc68";

Deserializers.creativeName = "DMJZ_PB4";

Deserializers.lunaAppID = "34802";

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

Deserializers.runtimeAnalysisExcludedClassesCount = "1743";

Deserializers.runtimeAnalysisExcludedMethodsCount = "4576";

Deserializers.runtimeAnalysisExcludedModules = "mecanim-wasm";

Deserializers.isRuntimeAnalysisEnabledForShaders = "True";

Deserializers.isRealtimeShadowsEnabled = "False";

Deserializers.isLunaCompilerV2Used = "False";

Deserializers.companyName = "DefaultCompany";

Deserializers.buildPlatform = "StandaloneWindows64";

Deserializers.applicationIdentifier = "com.Unity-Technologies.com.unity.template.urp-blank";

Deserializers.disableAntiAliasing = true;

Deserializers.graphicsConstraint = 24;

Deserializers.linearColorSpace = true;

Deserializers.buildID = "0b5110bd-ff1a-42fa-922c-81ac52b46fad";

Deserializers.runtimeInitializeOnLoadInfos = [[["UnityEngine","Rendering","DebugUpdater","RuntimeInit"],["Unity","PerformanceTesting","PerformanceTest","ResetStaticsOnLoad"],["Unity","Burst","BurstCompiler","ResetStaticsOnLoad"],["UnityEngine","Experimental","Rendering","ScriptableRuntimeReflectionSystemSettings","ScriptingDirtyReflectionSystemInstance"]],[["Unity","VisualScripting","GraphReference","ResetStaticsOnLoad"],["Unity","VisualScripting","RuntimeVSUsageUtility","RuntimeInitializeOnLoadBeforeSceneLoad"],["UnityEngine","InputSystem","PlayerInput","InitializeGlobalPlayerState"],["UnityEngine","InputSystem","InputSystem","RuntimeInitialize"],["UnityEngine","InputSystem","InputActionState","InitializeGlobalActionState"],["Unity","AI","Navigation","NavMeshModifierVolume","ClearNavMeshModifiers"],["Unity","AI","Navigation","NavMeshLink","ClearTrackedList"],["Unity","AI","Navigation","NavMeshSurface","ClearNavMeshSurfaces"],["Unity","AI","Navigation","NavMeshModifier","ClearNavMeshModifiers"],["UnityEngine","AI","NavMesh","ClearPreUpdateListeners"]],[["Unity","VisualScripting","Dependencies","NCalc","Expression","ResetStaticsOnLoad"],["Unity","VisualScripting","Flow","ResetStaticsOnLoad"],["Unity","VisualScripting","GraphInstances","ResetStaticsOnLoad"],["Unity","VisualScripting","FullSerializer","fsGlobalConfig","ResetStaticsOnLoad"],["Unity","VisualScripting","RuntimeCodebase","ResetStaticsOnLoad"],["Unity","VisualScripting","FullSerializer","fsAotCompilationManager","ResetStaticsOnLoad"],["Unity","VisualScripting","FullSerializer","fsSerializer","ResetStaticsOnLoad"],["Unity","VisualScripting","EventBus","ResetStaticsOnLoad"],["Unity","VisualScripting","Ensure","ResetStaticsOnLoad"],["Unity","VisualScripting","UnityThread","ResetStaticsOnLoad"],["Unity","VisualScripting","Recursion","ResetStaticsOnLoad"],["Unity","VisualScripting","SavedVariables","ResetStaticsOnLoad"],["Unity","VisualScripting","FullSerializer","fsMetaType","ResetStaticsOnLoad"],["Unity","VisualScripting","FullSerializer","fsResult","ResetStaticsOnLoad"],["Unity","VisualScripting","ApplicationVariables","ResetStaticsOnLoad"],["Unity","VisualScripting","MessageListener","ResetStaticsOnLoad"],["Unity","VisualScripting","Serialization","ResetStaticsOnLoad"],["Unity","VisualScripting","ReferenceCollector","ResetStaticsOnLoad"],["Unity","VisualScripting","OptimizedReflection","ResetStaticsOnLoad"],["Unity","VisualScripting","EditorTimeBinding","ResetStaticsOnLoad"],["Unity","VisualScripting","ProfilingUtility","ResetStaticsOnLoad"],["Unity","VisualScripting","FullSerializer","Internal","fsPortableReflection","ResetStaticsOnLoad"],["$BurstDirectCallInitializer","Initialize"],["$BurstDirectCallInitializer","Initialize"],["$BurstDirectCallInitializer","Initialize"],["$BurstDirectCallInitializer","Initialize"]],[["UnityEngine","Experimental","Rendering","XRSystem","XRSystemInit"]],[["UnityEngine","Timeline","AnimatorBindingCache","ResetStaticsOnLoad"],["UnityEngine","Timeline","TrackAsset","ResetStaticsOnLoad"],["UnityEngine","Timeline","AnimationPreviewUtilities","ResetStaticsOnLoad"],["Unity","PerformanceTesting","Data","RunSettings","ResetStaticsOnLoad"],["Unity","PerformanceTesting","PlayerCallbacks","ResetStaticsOnLoad"],["UnityEngine","InputSystem","Plugins","InputForUI","InputSystemProvider","Bootstrap"],["UnityEngine","InputSystem","EnhancedTouch","Touch","InitializeGlobalTouchState"],["UnityEngine","InputSystem","Users","InputUser","InitializeGlobalUserState"],["UnityEngine","InputSystem","UI","InputSystemUIInputModule","ResetDefaultActions"]]];

Deserializers.typeNameToIdMap = function(){ var i = 0; return Deserializers.types.reduce( function( res, item ) { res[ item ] = i++; return res; }, {} ) }()

