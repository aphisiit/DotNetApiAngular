using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TrainDotNetCore.Models
{
    public partial class PsmContext : DbContext
    {
        public PsmContext()
        {
        }

        public PsmContext(DbContextOptions<PsmContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppParameter> AppParameter { get; set; }
        public virtual DbSet<BoardCombination> BoardCombination { get; set; }
        public virtual DbSet<CorrugatingProcess> CorrugatingProcess { get; set; }
        public virtual DbSet<Flute> Flute { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<ParameterDetail> ParameterDetail { get; set; }
        public virtual DbSet<PrintingTechnology> PrintingTechnology { get; set; }
        public virtual DbSet<ProductSubType> ProductSubType { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost,9090;Initial Catalog=PSM;User ID=psm-adm;Password=p@ssw0rd");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<AppParameter>(entity =>
            {
                entity.ToTable("app_parameter");

                entity.HasIndex(e => e.Code)
                    .HasName("UK_gtiaw1dp6waq5evtqotn10uk4")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(19, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ParameterDescription)
                    .HasColumnName("parameter_description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("updated_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<BoardCombination>(entity =>
            {
                entity.ToTable("board_combination");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(19, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExternalCode)
                    .HasColumnName("external_code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FlagActive)
                    .HasColumnName("flag_active")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HighValueAdded)
                    .HasColumnName("high_value_added")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.Plant)
                    .HasColumnName("plant")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.PsmCluster)
                    .HasColumnName("psm_cluster")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.RemarkFluteCode)
                    .HasColumnName("remark_flute_code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TotalLayer).HasColumnName("total_layer");

                entity.Property(e => e.TotalWeight).HasColumnName("total_weight");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("updated_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<CorrugatingProcess>(entity =>
            {
                entity.ToTable("corrugating_process");

                entity.HasIndex(e => new { e.Code, e.Plant })
                    .HasName("UK_92dfdyker5sye56xfc7u0yc2v")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(19, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FlagActive)
                    .HasColumnName("flag_active")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HighValueAdded)
                    .HasColumnName("high_value_added")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.Plant)
                    .HasColumnName("plant")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.ProcessRatio).HasColumnName("process_ratio");

                entity.Property(e => e.PsmCluster)
                    .HasColumnName("psm_cluster")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("updated_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<Flute>(entity =>
            {
                entity.ToTable("flute");

                entity.HasIndex(e => new { e.Code, e.Plant })
                    .HasName("UQ__flute__55BD193FD53A4489")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(19, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BoxPerBundleDefault).HasColumnName("box_per_bundle_default");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.FlagActive)
                    .HasColumnName("flag_active")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GlueTab).HasColumnName("glue_tab");

                entity.Property(e => e.HighValueAdded)
                    .HasColumnName("high_value_added")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.LayerPerPalletDefault).HasColumnName("layer_per_pallet_default");

                entity.Property(e => e.OdThickness).HasColumnName("od_thickness");

                entity.Property(e => e.PaperPerPalletDefault).HasColumnName("paper_per_pallet_default");

                entity.Property(e => e.Plant)
                    .HasColumnName("plant")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.PsmCluster)
                    .HasColumnName("psm_cluster")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TakeupRatio).HasColumnName("takeup_ratio");

                entity.Property(e => e.TakeupRatio1).HasColumnName("takeup_ratio1");

                entity.Property(e => e.TakeupRatio2).HasColumnName("takeup_ratio2");

                entity.Property(e => e.Thickness).HasColumnName("thickness");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("updated_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Variablea).HasColumnName("variablea");

                entity.Property(e => e.Variabled).HasColumnName("variabled");

                entity.Property(e => e.Variablek).HasColumnName("variablek");

                entity.Property(e => e.Variables).HasColumnName("variables");

                entity.Property(e => e.Version).HasColumnName("version");

                entity.Property(e => e.Wall).HasColumnName("wall");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("item");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(19, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Areafg).HasColumnName("areafg");

                entity.Property(e => e.Assembly)
                    .HasColumnName("assembly")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.BagType)
                    .HasColumnName("bag_type")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.BdLength).HasColumnName("bd_length");

                entity.Property(e => e.BdWidth).HasColumnName("bd_width");

                entity.Property(e => e.BlockNumber)
                    .HasColumnName("block_number")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BlockNumberFromCopy)
                    .HasColumnName("block_number_from_copy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BlockType)
                    .HasColumnName("block_type")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.BoardCombination)
                    .HasColumnName("board_combination")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.BomMapNumber).HasColumnName("bom_map_number");

                entity.Property(e => e.BomMatNumber)
                    .HasColumnName("bom_mat_number")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BoxPerBundle).HasColumnName("box_per_bundle");

                entity.Property(e => e.BoxPerPallet).HasColumnName("box_per_pallet");

                entity.Property(e => e.BundlePerLayer).HasColumnName("bundle_per_layer");

                entity.Property(e => e.BundlePerPallet)
                    .HasColumnName("bundle_per_pallet")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.Coating)
                    .HasColumnName("coating")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.ColorFullString)
                    .HasColumnName("color_full_string")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ColorShadeFullString)
                    .HasColumnName("color_shade_full_string")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Contbm)
                    .HasColumnName("contbm")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Contbpcs)
                    .HasColumnName("contbpcs")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Contbt)
                    .HasColumnName("contbt")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CopyFrom)
                    .HasColumnName("copy_from")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.CorrugatingProcess)
                    .HasColumnName("corrugating_process")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.Costbpcs)
                    .HasColumnName("costbpcs")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CpOther)
                    .HasColumnName("cp_other")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CpPrintLayout)
                    .HasColumnName("cp_print_layout")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CpRemark)
                    .HasColumnName("cp_remark")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Customer)
                    .HasColumnName("customer")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.DdHeight).HasColumnName("dd_height");

                entity.Property(e => e.DdLength).HasColumnName("dd_length");

                entity.Property(e => e.DdWidth).HasColumnName("dd_width");

                entity.Property(e => e.DestinationCountry)
                    .HasColumnName("destination_country")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.DisplayArea)
                    .HasColumnName("display_area")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.DisplayDuration).HasColumnName("display_duration");

                entity.Property(e => e.DisplayLoadCapacity).HasColumnName("display_load_capacity");

                entity.Property(e => e.DisplayMoq).HasColumnName("display_moq");

                entity.Property(e => e.DisplayPackingType)
                    .HasColumnName("display_packing_type")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.DisplayRemarks)
                    .HasColumnName("display_remarks")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DisplaySpecialCondition)
                    .HasColumnName("display_special_condition")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayStackingLayer)
                    .HasColumnName("display_stacking_layer")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.DisplayTargetPrice).HasColumnName("display_target_price");

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.FgSheetLength).HasColumnName("fg_sheet_length");

                entity.Property(e => e.FgSheetWidth).HasColumnName("fg_sheet_width");

                entity.Property(e => e.FilmSpec)
                    .HasColumnName("film_spec")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FissureNum).HasColumnName("fissure_num");

                entity.Property(e => e.FlagAssembly)
                    .HasColumnName("flag_assembly")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FlagAutoSortColor)
                    .HasColumnName("flag_auto_sort_color")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FlagChangeProduct)
                    .HasColumnName("flag_change_product")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FlagJoinWidth)
                    .HasColumnName("flag_join_width")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FlagMulti)
                    .HasColumnName("flag_multi")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FlagOutterJoint)
                    .HasColumnName("flag_outter_joint")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FlagTwoPiecePerSet)
                    .HasColumnName("flag_two_piece_per_set")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FlagWithoutSlit)
                    .HasColumnName("flag_without_slit")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FlexibleMoq).HasColumnName("flexible_moq");

                entity.Property(e => e.FlexibleOtherFunction)
                    .HasColumnName("flexible_other_function")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.FlexiblePackingType)
                    .HasColumnName("flexible_packing_type")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.FlexibleRemarks)
                    .HasColumnName("flexible_remarks")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FlexibleTargetPrice).HasColumnName("flexible_target_price");

                entity.Property(e => e.Flute)
                    .HasColumnName("flute")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.FullSaleText)
                    .HasColumnName("full_sale_text")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GrossWeight).HasColumnName("gross_weight");

                entity.Property(e => e.HandlingType)
                    .HasColumnName("handling_type")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.IdHeight).HasColumnName("id_height");

                entity.Property(e => e.IdLength).HasColumnName("id_length");

                entity.Property(e => e.IdWidth).HasColumnName("id_width");

                entity.Property(e => e.Industry)
                    .HasColumnName("industry")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.ItemCode)
                    .HasColumnName("item_code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ItemRefer)
                    .HasColumnName("item_refer")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ItemStatus)
                    .HasColumnName("item_status")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.ItemType)
                    .HasColumnName("item_type")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.JoinSize).HasColumnName("join_size");

                entity.Property(e => e.JoinSizeAdjust).HasColumnName("join_size_adjust");

                entity.Property(e => e.JointLap).HasColumnName("joint_lap");

                entity.Property(e => e.JointType)
                    .HasColumnName("joint_type")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.LastEffectCostDate)
                    .HasColumnName("last_effect_cost_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.LayerPerPallet).HasColumnName("layer_per_pallet");

                entity.Property(e => e.LpInput)
                    .HasColumnName("lp_input")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LpStatus)
                    .HasColumnName("lp_status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Marginbm)
                    .HasColumnName("marginbm")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Marginbp)
                    .HasColumnName("marginbp")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Marginbt)
                    .HasColumnName("marginbt")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MaterialDescription)
                    .HasColumnName("material_description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MaterialNumber)
                    .HasColumnName("material_number")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MerchandisingDisplayMaterialType)
                    .HasColumnName("merchandising_display_material_type")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.MerchandisingDisplayType)
                    .HasColumnName("merchandising_display_type")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.MultiItemContribute).HasColumnName("multi_item_contribute");

                entity.Property(e => e.MultiItemSellingPrice).HasColumnName("multi_item_selling_price");

                entity.Property(e => e.MultiItemSequence).HasColumnName("multi_item_sequence");

                entity.Property(e => e.MultiItemUploadRunning)
                    .HasColumnName("multi_item_upload_running")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MultiLpGroup)
                    .HasColumnName("multi_lp_group")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MultiLpMarkUp)
                    .HasColumnName("multi_lp_mark_up")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MultiRunning)
                    .HasColumnName("multi_running")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MultiUploadSequence).HasColumnName("multi_upload_sequence");

                entity.Property(e => e.MultilppercentMargin)
                    .HasColumnName("multilppercent_margin")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NumColor).HasColumnName("num_color");

                entity.Property(e => e.NumColorDisplay).HasColumnName("num_color_display");

                entity.Property(e => e.NumColorFlex).HasColumnName("num_color_flex");

                entity.Property(e => e.NumberOfCut).HasColumnName("number_of_cut");

                entity.Property(e => e.OdHeight).HasColumnName("od_height");

                entity.Property(e => e.OdLength).HasColumnName("od_length");

                entity.Property(e => e.OdWidth).HasColumnName("od_width");

                entity.Property(e => e.OldChangeDetail)
                    .HasColumnName("old_change_detail")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OrderPlant)
                    .HasColumnName("order_plant")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.OrderUser)
                    .HasColumnName("order_user")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OverHangLength).HasColumnName("over_hang_length");

                entity.Property(e => e.OverHangWidth).HasColumnName("over_hang_width");

                entity.Property(e => e.PackingMethod)
                    .HasColumnName("packing_method")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.Pallet)
                    .HasColumnName("pallet")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.PalletHeight).HasColumnName("pallet_height");

                entity.Property(e => e.PalletImgSelected).HasColumnName("pallet_img_selected");

                entity.Property(e => e.PalletLength).HasColumnName("pallet_length");

                entity.Property(e => e.PalletLoadCapacity)
                    .HasColumnName("pallet_load_capacity")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PalletLoadType)
                    .HasColumnName("pallet_load_type")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PalletMaterialType)
                    .HasColumnName("pallet_material_type")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.PalletMoq).HasColumnName("pallet_moq");

                entity.Property(e => e.PalletPackingType)
                    .HasColumnName("pallet_packing_type")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.PalletRemarks)
                    .HasColumnName("pallet_remarks")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PalletSpecialCondition)
                    .HasColumnName("pallet_special_condition")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PalletStackingLayer)
                    .HasColumnName("pallet_stacking_layer")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.PalletStackingLayerOther).HasColumnName("pallet_stacking_layer_other");

                entity.Property(e => e.PalletTargetPrice).HasColumnName("pallet_target_price");

                entity.Property(e => e.PalletType)
                    .HasColumnName("pallet_type")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.PalletWidth).HasColumnName("pallet_width");

                entity.Property(e => e.PaperWidth)
                    .HasColumnName("paper_width")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PartNumber)
                    .HasColumnName("part_number")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PcCodePrefix)
                    .HasColumnName("pc_code_prefix")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PcCodeRunning)
                    .HasColumnName("pc_code_running")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PcCodeSuffix)
                    .HasColumnName("pc_code_suffix")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PdHeight).HasColumnName("pd_height");

                entity.Property(e => e.PdLength).HasColumnName("pd_length");

                entity.Property(e => e.PdWidth).HasColumnName("pd_width");

                entity.Property(e => e.PiecePerSet).HasColumnName("piece_per_set");

                entity.Property(e => e.Plant)
                    .HasColumnName("plant")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.PlateNumber)
                    .HasColumnName("plate_number")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PriceBahtPerTon).HasColumnName("price_baht_per_ton");

                entity.Property(e => e.PriceBahtPerTonProductionPlant).HasColumnName("price_baht_per_ton_production_plant");

                entity.Property(e => e.PricePerPiece).HasColumnName("price_per_piece");

                entity.Property(e => e.PricePerPieceProd).HasColumnName("price_per_piece_prod");

                entity.Property(e => e.PricePerPieceProductionPlant).HasColumnName("price_per_piece_production_plant");

                entity.Property(e => e.PrimaryPackaging)
                    .HasColumnName("primary_packaging")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.PrintMethod)
                    .HasColumnName("print_method")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.PrintingAround2)
                    .HasColumnName("printing_around2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrintingSolid3)
                    .HasColumnName("printing_solid3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrintingTechnology)
                    .HasColumnName("printing_technology")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.PrintingTechnologyDisplay)
                    .HasColumnName("printing_technology_display")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.PrintingTechnologyFlex)
                    .HasColumnName("printing_technology_flex")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.ProductCreateDate)
                    .HasColumnName("product_create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductGroup)
                    .HasColumnName("product_group")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.ProductLastUpdate)
                    .HasColumnName("product_last_update")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductSubType)
                    .HasColumnName("product_sub_type")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.ProductType)
                    .HasColumnName("product_type")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.ProductionPlan)
                    .HasColumnName("production_plan")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProductionPlantDetail)
                    .HasColumnName("production_plant_detail")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProductionPlantStatus)
                    .HasColumnName("production_plant_status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PsmCluster)
                    .HasColumnName("psm_cluster")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.QuantityPerPack).HasColumnName("quantity_per_pack");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnName("release_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RequestStatus)
                    .HasColumnName("request_status")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.RequestStatusArtwork)
                    .HasColumnName("request_status_artwork")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.RequestStatusDrawing)
                    .HasColumnName("request_status_drawing")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.SaleText)
                    .HasColumnName("sale_text")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ScoreLinel2).HasColumnName("score_linel2");

                entity.Property(e => e.ScoreLinel3).HasColumnName("score_linel3");

                entity.Property(e => e.ScoreLinel4).HasColumnName("score_linel4");

                entity.Property(e => e.ScoreLinel5).HasColumnName("score_linel5");

                entity.Property(e => e.ScoreLinel6).HasColumnName("score_linel6");

                entity.Property(e => e.ScoreLinel7).HasColumnName("score_linel7");

                entity.Property(e => e.ScoreLinel8).HasColumnName("score_linel8");

                entity.Property(e => e.ScoreLinel9).HasColumnName("score_linel9");

                entity.Property(e => e.ScoreLinew1).HasColumnName("score_linew1");

                entity.Property(e => e.ScoreLinew2).HasColumnName("score_linew2");

                entity.Property(e => e.ScoreLinew3).HasColumnName("score_linew3");

                entity.Property(e => e.SdHeight).HasColumnName("sd_height");

                entity.Property(e => e.SdLength).HasColumnName("sd_length");

                entity.Property(e => e.SdWidth).HasColumnName("sd_width");

                entity.Property(e => e.SecondaryPackaging)
                    .HasColumnName("secondary_packaging")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.Sellingbm)
                    .HasColumnName("sellingbm")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sellingbpcs)
                    .HasColumnName("sellingbpcs")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sellingbt)
                    .HasColumnName("sellingbt")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SetNumber)
                    .HasColumnName("set_number")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ShelfLife)
                    .HasColumnName("shelf_life")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.Slit).HasColumnName("slit");

                entity.Property(e => e.StackingLayer).HasColumnName("stacking_layer");

                entity.Property(e => e.StaplerNum).HasColumnName("stapler_num");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TagWord)
                    .HasColumnName("tag_word")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ThicknessOfFilm).HasColumnName("thickness_of_film");

                entity.Property(e => e.TransportCondition)
                    .HasColumnName("transport_condition")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.TransportationDuration).HasColumnName("transportation_duration");

                entity.Property(e => e.TransportationType)
                    .HasColumnName("transportation_type")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.TrimWaste).HasColumnName("trim_waste");

                entity.Property(e => e.TrimWastePercentage).HasColumnName("trim_waste_percentage");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("updated_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsageConditions)
                    .HasColumnName("usage_conditions")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.VendorPrice).HasColumnName("vendor_price");

                entity.Property(e => e.Version).HasColumnName("version");

                entity.Property(e => e.VersionUpdateItemSpec).HasColumnName("version_update_item_spec");

                entity.Property(e => e.WeightPerUnit).HasColumnName("weight_per_unit");

                entity.Property(e => e.WeightPerUnitInsight).HasColumnName("weight_per_unit_insight");

                entity.HasOne(d => d.BoardCombinationNavigation)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.BoardCombination)
                    .HasConstraintName("FK_tca215edg4pvlyhqk7ci3fn05");

                entity.HasOne(d => d.CorrugatingProcessNavigation)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.CorrugatingProcess)
                    .HasConstraintName("FK_4ikc285ngcvoqfqpei46a6usf");

                entity.HasOne(d => d.FluteNavigation)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.Flute)
                    .HasConstraintName("FK_ls758qj0y13t8igamyt0hijcu");

                entity.HasOne(d => d.PrintingTechnologyNavigation)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.PrintingTechnology)
                    .HasConstraintName("FK_fxa2m73qdqon812f0yidv1uhd");

                entity.HasOne(d => d.ProductSubTypeNavigation)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.ProductSubType)
                    .HasConstraintName("FK_bmb6cyhm43illfvhu5olak1sh");

                entity.HasOne(d => d.ProductTypeNavigation)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.ProductType)
                    .HasConstraintName("FK_702kh2yttjppnhxg39oyqjaa4");
            });

            modelBuilder.Entity<ParameterDetail>(entity =>
            {
                entity.ToTable("parameter_detail");

                entity.HasIndex(e => new { e.Code, e.AppParameter })
                    .HasName("UK_t5w89twlin0k5gq84vooo0dq")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(19, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AppParameter)
                    .HasColumnName("app_parameter")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CommentParameterValue1)
                    .HasColumnName("comment_parameter_value1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CommentParameterValue10)
                    .HasColumnName("comment_parameter_value10")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CommentParameterValue2)
                    .HasColumnName("comment_parameter_value2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CommentParameterValue3)
                    .HasColumnName("comment_parameter_value3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CommentParameterValue4)
                    .HasColumnName("comment_parameter_value4")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CommentParameterValue5)
                    .HasColumnName("comment_parameter_value5")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CommentParameterValue6)
                    .HasColumnName("comment_parameter_value6")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CommentParameterValue7)
                    .HasColumnName("comment_parameter_value7")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CommentParameterValue8)
                    .HasColumnName("comment_parameter_value8")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CommentParameterValue9)
                    .HasColumnName("comment_parameter_value9")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ParameterDescription)
                    .HasColumnName("parameter_description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParameterValue1)
                    .HasColumnName("parameter_value1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParameterValue10)
                    .HasColumnName("parameter_value10")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParameterValue2)
                    .HasColumnName("parameter_value2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParameterValue3)
                    .HasColumnName("parameter_value3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParameterValue4)
                    .HasColumnName("parameter_value4")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParameterValue5)
                    .HasColumnName("parameter_value5")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParameterValue6)
                    .HasColumnName("parameter_value6")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParameterValue7)
                    .HasColumnName("parameter_value7")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParameterValue8)
                    .HasColumnName("parameter_value8")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParameterValue9)
                    .HasColumnName("parameter_value9")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("updated_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Version).HasColumnName("version");

                entity.HasOne(d => d.AppParameterNavigation)
                    .WithMany(p => p.ParameterDetail)
                    .HasForeignKey(d => d.AppParameter)
                    .HasConstraintName("FK_81ybinmyp8gbvewkd5hqupv84");
            });

            modelBuilder.Entity<PrintingTechnology>(entity =>
            {
                entity.ToTable("printing_technology");

                entity.HasIndex(e => e.Code)
                    .HasName("UK_t20liw099034qt1s4hfeajwie")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(19, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FlagActive)
                    .HasColumnName("flag_active")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FlagDefault)
                    .HasColumnName("flag_default")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FlagPrePrint)
                    .HasColumnName("flag_pre_print")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HighValueAdded)
                    .HasColumnName("high_value_added")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("updated_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<ProductSubType>(entity =>
            {
                entity.ToTable("product_sub_type");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(19, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FlagActive)
                    .HasColumnName("flag_active")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FlagDefault)
                    .HasColumnName("flag_default")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HighValueAdded)
                    .HasColumnName("high_value_added")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.ProductCodeSuffix)
                    .HasColumnName("product_code_suffix")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProductType)
                    .HasColumnName("product_type")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("updated_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Version).HasColumnName("version");

                entity.HasOne(d => d.ProductTypeNavigation)
                    .WithMany(p => p.ProductSubType)
                    .HasForeignKey(d => d.ProductType)
                    .HasConstraintName("FK_p5byax7tjnhg0enybbkn1f0vx");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("product_type");

                entity.HasIndex(e => new { e.Code, e.Plant, e.Description })
                    .HasName("UK_59b719rick22o0xy1ffsto585")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(19, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DrawingFileName)
                    .HasColumnName("drawing_file_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DrawingRealFileName)
                    .HasColumnName("drawing_real_file_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FlagActive)
                    .HasColumnName("flag_active")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FlagCorrugatedPartition)
                    .HasColumnName("flag_corrugated_partition")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FlagSpecialProductType)
                    .HasColumnName("flag_special_product_type")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HierachyLevel2)
                    .HasColumnName("hierachy_level2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HighValueAdded)
                    .HasColumnName("high_value_added")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.LeadTime).HasColumnName("lead_time");

                entity.Property(e => e.MaterialTypeDesc)
                    .HasColumnName("material_type_desc")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PlanProcess)
                    .HasColumnName("plan_process")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.Plant)
                    .HasColumnName("plant")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.ProductCodeSuffix)
                    .HasColumnName("product_code_suffix")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProductGroupType)
                    .HasColumnName("product_group_type")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.PsmCluster)
                    .HasColumnName("psm_cluster")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.Sequence).HasColumnName("sequence");

                entity.Property(e => e.ShortName)
                    .HasColumnName("short_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("updated_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.UploadTime)
                    .HasColumnName("upload_time")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Version).HasColumnName("version");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}