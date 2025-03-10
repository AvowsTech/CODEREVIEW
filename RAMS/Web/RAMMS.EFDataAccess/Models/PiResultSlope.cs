﻿using System;
using System.Collections.Generic;

namespace RAMMS.EFDataAccess.Models
{
    public partial class PiResultSlope
    {
        public PiResultSlope()
        {
            PiResultSlopeFurtherInvestigation = new HashSet<PiResultSlopeFurtherInvestigation>();
            PiResultSlopePhoto = new HashSet<PiResultSlopePhoto>();
            PiResultSlopeRemedialWork = new HashSet<PiResultSlopeRemedialWork>();
            PiResultSlopeRoutineWork = new HashSet<PiResultSlopeRoutineWork>();
        }

        public int PiSchedulePk { get; set; }
        public string GenInfoTypeOfInspection { get; set; }
        public string GenInfoDiskNo { get; set; }
        public string GenInfoPhotoNo { get; set; }
        public string GenInfoSlopeOnBend { get; set; }
        public string GenInfoAccessibility { get; set; }
        public string GeologicalLithology { get; set; }
        public int? GeologicalDiscontinuity { get; set; }
        public string GeologicalSoilRockInterface { get; set; }
        public string GeologicalAdversity { get; set; }
        public string GeologicalWeathering { get; set; }
        public string GeologicalMajorStructure { get; set; }
        public bool? VegetatedSurfaceIsRelevant { get; set; }
        public string VegetatedSurfaceCondition { get; set; }
        public bool? VegetatedSurfaceWorkRequired { get; set; }
        public string VegetatedSurfaceWorkDetails { get; set; }
        public string VegCoverageCondition { get; set; }
        public string VegCoverageDueTo { get; set; }
        public bool? HardCoverIsRelevant { get; set; }
        public string HardCoverCondition { get; set; }
        public bool? HardCoverWorkRequired { get; set; }
        public string HardCoverWorkDetails { get; set; }
        public string StructureCondCondition { get; set; }
        public int? HardCoverPercentage { get; set; }
        public string HardCoverLocation { get; set; }
        public bool? LooseMaterialIsRelevant { get; set; }
        public string LooseMaterialCondition { get; set; }
        public bool? LooseMaterialWorkRequired { get; set; }
        public string LooseMaterialWorkDetails { get; set; }
        public bool? ScalingIsRequired { get; set; }
        public string ScalingLocation { get; set; }
        public string ScalingType { get; set; }
        public string GeneralSurfaceCondition { get; set; }
        public string CatchmentArea { get; set; }
        public bool? AboveDevIsRelevant { get; set; }
        public string AboveDevCondition { get; set; }
        public bool? InterceptorDrainsIsRelevant { get; set; }
        public string InterceptorDrainsServiceabilityStatus { get; set; }
        public string InterceptorDrainsStructuralDefect { get; set; }
        public bool? InterceptorDrainsWorkRequired { get; set; }
        public string InterceptorDrainsWorkDetails { get; set; }
        public bool? BermDrainsIsRelevant { get; set; }
        public string BermDrainsServiceabilityStatus { get; set; }
        public string BermDrainsStructuralDefect { get; set; }
        public bool? BermDrainsWorkRequired { get; set; }
        public string BermDrainsWorkDetails { get; set; }
        public bool? ToeDrainsIsRelevant { get; set; }
        public string ToeDrainsServiceabilityStatus { get; set; }
        public string ToeDrainsStructuralDefect { get; set; }
        public bool? ToeDrainsWorkRequired { get; set; }
        public string ToeDrainsWorkDetails { get; set; }
        public bool? SlopeDrainsIsRelevant { get; set; }
        public string SlopeDrainsServiceabilityStatus { get; set; }
        public string SlopeDrainsStructuralDefect { get; set; }
        public bool? SlopeDrainsWorkRequired { get; set; }
        public string SlopeDrainsWorkDetails { get; set; }
        public bool? ShoulderDrainsIsRelevant { get; set; }
        public string ShoulderDrainsServiceabilityStatus { get; set; }
        public string ShoulderDrainsStructuralDefect { get; set; }
        public bool? ShoulderDrainsWorkRequired { get; set; }
        public string ShoulderDrainsWorkDetails { get; set; }
        public bool? CatchPitsIsRelevant { get; set; }
        public string CatchPitsServiceabilityStatus { get; set; }
        public string CatchPitsStructuralDefect { get; set; }
        public bool? CatchPitsWorkRequired { get; set; }
        public string CatchPitsWorkDetails { get; set; }
        public bool? WeepHolesRelevant { get; set; }
        public string WeepHolesServiceabilityStatus { get; set; }
        public string WeepHolesStructuralDefect { get; set; }
        public bool? WeepHolesWorkRequired { get; set; }
        public string WeepHolesWorkDetails { get; set; }
        public bool? HorizontalDrainsIsRelevant { get; set; }
        public string HorizontalDrainsServiceabilityStatus { get; set; }
        public string HorizontalDrainsStructuralDefect { get; set; }
        public bool? HorizontalDrainsWorkRequired { get; set; }
        public string HorizontalDrainsWorkDetails { get; set; }
        public bool? RockDitchIsRelevant { get; set; }
        public double? RockDitchServiceabilityWidth { get; set; }
        public double? RockDitchServiceabilityDepth { get; set; }
        public string RockDitchStructuralDefect { get; set; }
        public bool? RockDitchWorkRequired { get; set; }
        public string RockDitchWorkDetails { get; set; }
        public string ScouringDrainsCondition { get; set; }
        public bool? ScouringDrainsWorkRequired { get; set; }
        public string ScouringDrainsWorkDetails { get; set; }
        public string OpenGapsCondition { get; set; }
        public bool? OpenGapsWorkRequired { get; set; }
        public string OpenGapsWorkDetails { get; set; }
        public string GeneralDrainageCondition { get; set; }
        public bool? InstabilitySignIsRelevant { get; set; }
        public string InstabilitySignCondition { get; set; }
        public bool? InstabilitySignWorkRequired { get; set; }
        public string InstabilitySignWorkDetails { get; set; }
        public string InstabilityDegreeCondition { get; set; }
        public bool? SlopeFailureIsRelevant { get; set; }
        public string SlopeFailureCondition { get; set; }
        public bool? SlopeFailureWorkRequired { get; set; }
        public string SlopeFailureWorkDetails { get; set; }
        public string SlopeFailureSlopeSurfaceNo { get; set; }
        public double? SlopeFailureWidth { get; set; }
        public double? SlopeFailureHeight { get; set; }
        public string SlopeFailureCauseofFailure { get; set; }
        public bool? PreviousFailureIsRelevant { get; set; }
        public string PreviousFailureLocation { get; set; }
        public string PreviousFailureRemedialWork { get; set; }
        public bool? ErosionIsRelevant { get; set; }
        public string ErosionCondition { get; set; }
        public bool? ErosionWorkRequired { get; set; }
        public string ErosionWorkDetails { get; set; }
        public string ErosionDegreeCondition { get; set; }
        public double? ErosionDegreeAreaAffected { get; set; }
        public string ErosionDegreeLocation { get; set; }
        public bool? WaterFlowIsRelevant { get; set; }
        public string WaterFlowEvidence { get; set; }
        public string SeepageCondition { get; set; }
        public string SeepageLocation { get; set; }
        public bool? SeepageWorkRequired { get; set; }
        public string SeepageWorkDetails { get; set; }
        public bool? GeoDiscontinuityIsRelevant { get; set; }
        public string GeoDiscontinuityCondition { get; set; }
        public bool? GeoDiscontinuityWorkRequired { get; set; }
        public string GeoDiscontinuityWorkDetails { get; set; }
        public string RoadDistressCondition { get; set; }
        public string GeneralDistressCondition { get; set; }
        public string SlopeDistressRemark { get; set; }
        public bool? ExistingWorksAnyExistingWorks { get; set; }
        public string ExistingWorksCondition { get; set; }
        public bool? VisualDefectAnyVisualDefect { get; set; }
        public string VisualDefectCondition { get; set; }
        public bool? VisualDefectWorkRequired { get; set; }
        public string VisualDefectWorkDetails { get; set; }
        public string SevDefectCondition { get; set; }
        public bool? RockFallIsRelevant { get; set; }
        public string RockFallCondition { get; set; }
        public bool? RockFallWorkRequired { get; set; }
        public string RockFallWorkDetails { get; set; }
        public bool? RockFallAnyVisualDefect { get; set; }
        public string RockFallVisualCondition { get; set; }
        public string ExistingStabilizingWorksCondition { get; set; }
        public string SummaryOverall { get; set; }
        public string PriorityRatingCode { get; set; }
        public string SketchPlan { get; set; }
        public string SketchSection { get; set; }
        public string SketchSlope { get; set; }

        public virtual PiSchedule PiSchedulePkNavigation { get; set; }
        public virtual ICollection<PiResultSlopeFurtherInvestigation> PiResultSlopeFurtherInvestigation { get; set; }
        public virtual ICollection<PiResultSlopePhoto> PiResultSlopePhoto { get; set; }
        public virtual ICollection<PiResultSlopeRemedialWork> PiResultSlopeRemedialWork { get; set; }
        public virtual ICollection<PiResultSlopeRoutineWork> PiResultSlopeRoutineWork { get; set; }
    }
}
