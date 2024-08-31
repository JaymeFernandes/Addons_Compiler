﻿using System;
using System.IO;


namespace Addons
{
    /// <summary>
    /// Represents the hand types for rendering.
    /// </summary>
    public enum HandTypes
    {
        MainHand,
        OffHand
    }

    /// <summary>
    /// Represents the view types for rendering.
    /// </summary>
    public enum ViewTypes
    {
        FirstPerson,
        ThirdPerson
    }

    public enum SaturationModifier
    {
        Low,
        Normal,
        High
    }


    public enum AddonType
    {
        Data,
        Resources,
        Scripting,
        Interface,
        SkinPack,
        WorldTemplate
    }

    public enum TextureType
    {
        Items,
        Terrain,
        Entity,
        Environment,
        Gui,
        Misc,
        Particles
    }
    public static class Minecraft 
    {
        public static class Color
        {
            public const string Black = "§0";
            public const string Dark_blue = "§1";
            public const string Dark_green = "§2";
            public const string Dark_aqua = "§3";
            public const string Dark_red = "§4";
            public const string Dark_purple = "§5";
            public const string Gold = "§6";
            public const string Gray = "§7";
            public const string Dark_gray = "§8";
            public const string Blue = "§9";
            public const string Green = "§a";
            public const string Aqua = "§b";
            public const string Red = "§c";
            public const string Light_purple = "§d";
            public const string Yellow = "§e";
            public const string White = "§f";
            public const string Minecoin_gold = "§g";
            public const string Material_quartz = "§h";
            public const string Material_iron = "§i";
            public const string Material_netherite = "§j";
            public const string Material_redstone = "§m";
            public const string Material_copper = "§n";
            public const string Material_gold = "§p";
            public const string Material_emerald = "§q";
            public const string Material_diamond = "§s";
            public const string Material_lapis = "§t";
            public const string Material_amethyst = "§u";
        }

        public static class Formatting
        {
            public const string Obfuscated = "§k";
            public const string Bold = "§l";
            public const string italic = "§o";
            public const string reset = "§r";
        }

        public static class Item
        {
            public const string AcaciaBoat = "minecraft:acacia_boat";
            public const string AcaciaButton = "minecraft:acacia_button";
            public const string AcaciaDoor = "minecraft:acacia_door";
            public const string AcaciaFenceGate = "minecraft:acacia_fence_gate";
            public const string AcaciaPressurePlate = "minecraft:acacia_pressure_plate";
            public const string AcaciaSign = "minecraft:acacia_sign";
            public const string AcaciaStairs = "minecraft:acacia_stairs";
            public const string AcaciaTrapdoor = "minecraft:acacia_trapdoor";
            public const string ActivatorRail = "minecraft:activator_rail";
            public const string Air = "minecraft:air";
            public const string AllowBlock = "minecraft:allow";
            public const string AncientDebris = "minecraft:ancient_debris";
            public const string AndesiteStairs = "minecraft:andesite_stairs";
            public const string Anvil = "minecraft:anvil";
            public const string SlightlyDamagedAnvil = "minecraft:anvil";
            public const string VeryDamagedAnvil = "minecraft:anvil";
            public const string Apple = "minecraft:apple";
            public const string ArmorStand = "minecraft:armor_stand";
            public const string Arrow = "minecraft:arrow";
            public const string BakedPotato = "minecraft:baked_potato";
            public const string Bamboo = "minecraft:bamboo";
            public const string Barrel = "minecraft:barrel";
            public const string Barrier = "minecraft:barrier";
            public const string Basalt = "minecraft:basalt";
            public const string BatSpawnEgg = "minecraft:bat_spawn_egg";
            public const string Beacon = "minecraft:beacon";
            public const string WhiteBed = "minecraft:bed";
            public const string OrangeBed = "minecraft:bed";
            public const string MagentaBed = "minecraft:bed";
            public const string LightBlueBed = "minecraft:bed";
            public const string YellowBed = "minecraft:bed";
            public const string LimeBed = "minecraft:bed";
            public const string PinkBed = "minecraft:bed";
            public const string GrayBed = "minecraft:bed";
            public const string LightGrayBed = "minecraft:bed";
            public const string CyanBed = "minecraft:bed";
            public const string PurpleBed = "minecraft:bed";
            public const string BlueBed = "minecraft:bed";
            public const string BrownBed = "minecraft:bed";
            public const string GreenBed = "minecraft:bed";
            public const string RedBed = "minecraft:bed";
            public const string BlackBed = "minecraft:bed";
            public const string Bedrock = "minecraft:bedrock";
            public const string BeeNest = "minecraft:bee_nest";
            public const string BeeSpawnEgg = "minecraft:bee_spawn_egg";
            public const string RawBeef = "minecraft:beef";
            public const string Beehive = "minecraft:beehive";
            public const string Beetroot = "minecraft:beetroot";
            public const string BeetrootSeeds = "minecraft:beetroot_seeds";
            public const string BeetrootSoup = "minecraft:beetroot_soup";
            public const string Bell = "minecraft:bell";
            public const string BirchBoat = "minecraft:birch_boat";
            public const string BirchButton = "minecraft:birch_button";
            public const string BirchDoor = "minecraft:birch_door";
            public const string BirchFenceGate = "minecraft:birch_fence_gate";
            public const string BirchPressurePlate = "minecraft:birch_pressure_plate";
            public const string BirchSign = "minecraft:birch_sign";
            public const string BirchStairs = "minecraft:birch_stairs";
            public const string BirchTrapdoor = "minecraft:birch_trapdoor";
            public const string BlackDye = "minecraft:black_dye";
            public const string BlackGlazedTerracotta = "minecraft:black_glazed_terracotta";
            public const string Blackstone = "minecraft:blackstone";
            public const string BlackstoneSlab = "minecraft:blackstone_slab";
            public const string BlackstoneStairs = "minecraft:blackstone_stairs";
            public const string BlackstoneWall = "minecraft:blackstone_wall";
            public const string BlastFurnace = "minecraft:blast_furnace";
            public const string BlazePowder = "minecraft:blaze_powder";
            public const string BlazeRod = "minecraft:blaze_rod";
            public const string BlazeSpawnEgg = "minecraft:blaze_spawn_egg";
            public const string BlueDye = "minecraft:blue_dye";
            public const string BlueGlazedTerracotta = "minecraft:blue_glazed_terracotta";
            public const string BlueIce = "minecraft:blue_ice";
            public const string Bone = "minecraft:bone";
            public const string BoneBlock = "minecraft:bone_block";
            public const string BoneMeal = "minecraft:bone_meal";
            public const string Book = "minecraft:book";
            public const string Bookshelf = "minecraft:bookshelf";
            public const string BorderBlock = "minecraft:border_block";
            public const string BordureIndentedBannerPattern = "minecraft:bordure_indented_banner_pattern";
            public const string Bow = "minecraft:bow";
            public const string Bowl = "minecraft:bowl";
            public const string Bread = "minecraft:bread";
            public const string BrewingStand = "minecraft:brewing_stand";
            public const string Brick = "minecraft:brick";
            public const string Bricks = "minecraft:brick_block";
            public const string BrickStairs = "minecraft:brick_stairs";
            public const string BrownDye = "minecraft:brown_dye";
            public const string BrownGlazedTerracotta = "minecraft:brown_glazed_terracotta";
            public const string BrownMushroom = "minecraft:brown_mushroom";
            public const string LightBrownMushroomBlock = "minecraft:brown_mushroom_block";
            public const string BrownMushroomBlock = "minecraft:brown_mushroom_block";
            public const string MushroomStem = "minecraft:brown_mushroom_block";
            public const string Bucket = "minecraft:bucket";
            public const string Cactus = "minecraft:cactus";
            public const string Cake = "minecraft:cake";
            public const string Campfire = "minecraft:campfire";
            public const string WhiteCarpet = "minecraft:carpet";
            public const string OrangeCarpet = "minecraft:carpet";
            public const string MagentaCarpet = "minecraft:carpet";
            public const string LightBlueCarpet = "minecraft:carpet";
            public const string YellowCarpet = "minecraft:carpet";
            public const string LimeCarpet = "minecraft:carpet";
            public const string PinkCarpet = "minecraft:carpet";
            public const string GrayCarpet = "minecraft:carpet";
            public const string LightGrayCarpet = "minecraft:carpet";
            public const string CyanCarpet = "minecraft:carpet";
            public const string PurpleCarpet = "minecraft:carpet";
            public const string BlueCarpet = "minecraft:carpet";
            public const string BrownCarpet = "minecraft:carpet";
            public const string GreenCarpet = "minecraft:carpet";
            public const string RedCarpet = "minecraft:carpet";
            public const string BlackCarpet = "minecraft:carpet";
            public const string Carrot = "minecraft:carrot";
            public const string CarrotOnAStick = "minecraft:carrot_on_a_stick";
            public const string CartographyTable = "minecraft:cartography_table";
            public const string CarvedPumpkin = "minecraft:carved_pumpkin";
            public const string CatSpawnEgg = "minecraft:cat_spawn_egg";
            public const string Cauldron = "minecraft:cauldron";
            public const string CaveSpiderSpawnEgg = "minecraft:cave_spider_spawn_egg";
            public const string Chain = "minecraft:chain";
            public const string ChainCommandBlock = "minecraft:chain_command_block";
            public const string ChainBoots = "minecraft:chainmail_boots";
            public const string ChainChestplate = "minecraft:chainmail_chestplate";
            public const string ChainHelmet = "minecraft:chainmail_helmet";
            public const string ChainLeggings = "minecraft:chainmail_leggings";
            public const string Charcoal = "minecraft:charcoal";
            public const string Chest = "minecraft:chest";
            public const string MinecartWithChest = "minecraft:chest_minecart";
            public const string RawChicken = "minecraft:chicken";
            public const string ChickenSpawnEgg = "minecraft:chicken_spawn_egg";
            public const string ChiseledNetherBricks = "minecraft:chiseled_nether_bricks";
            public const string ChiseledPolishedBlackstone = "minecraft:chiseled_polished_blackstone";
            public const string ChorusFlower = "minecraft:chorus_flower";
            public const string ChorusFruit = "minecraft:chorus_fruit";
            public const string ChorusPlant = "minecraft:chorus_plant";
            public const string ClayBlock = "minecraft:clay";
            public const string ClayBall = "minecraft:clay_ball";
            public const string Clock = "minecraft:clock";
            public const string Coal = "minecraft:coal";
            public const string CoalBlock = "minecraft:coal_block";
            public const string CoalOre = "minecraft:coal_ore";
            public const string Cobblestone = "minecraft:cobblestone";
            public const string CobblestoneWall = "minecraft:cobblestone_wall";
            public const string MossyCobblestoneWall = "minecraft:cobblestone_wall";
            public const string GraniteWall = "minecraft:cobblestone_wall";
            public const string DioriteWall = "minecraft:cobblestone_wall";
            public const string AndesiteWall = "minecraft:cobblestone_wall";
            public const string SandstoneWall = "minecraft:cobblestone_wall";
            public const string BrickWall = "minecraft:cobblestone_wall";
            public const string StoneBrickWall = "minecraft:cobblestone_wall";
            public const string MossyStoneBrickWall = "minecraft:cobblestone_wall";
            public const string NetherBrickWall = "minecraft:cobblestone_wall";
            public const string EndStoneBrickWall = "minecraft:cobblestone_wall";
            public const string PrismarineWall = "minecraft:cobblestone_wall";
            public const string RedSandstoneWall = "minecraft:cobblestone_wall";
            public const string RedNetherBrickWall = "minecraft:cobblestone_wall";
            public const string CocoaBeans = "minecraft:cocoa_beans";
            public const string RawCod = "minecraft:cod";
            public const string BucketOfCod = "minecraft:cod_bucket";
            public const string CodSpawnEgg = "minecraft:cod_spawn_egg";
            public const string CommandBlock = "minecraft:command_block";
            public const string MinecartWithCommandBlock = "minecraft:command_block_minecart";
            public const string RedstoneComparator = "minecraft:comparator";
            public const string Compass = "minecraft:compass";
            public const string Composter = "minecraft:composter";
            public const string WhiteConcrete = "minecraft:concrete";
            public const string OrangeConcrete = "minecraft:concrete";
            public const string MagentaConcrete = "minecraft:concrete";
            public const string LightBlueConcrete = "minecraft:concrete";
            public const string YellowConcrete = "minecraft:concrete";
            public const string LimeConcrete = "minecraft:concrete";
            public const string PinkConcrete = "minecraft:concrete";
            public const string GrayConcrete = "minecraft:concrete";
            public const string LightGrayConcrete = "minecraft:concrete";
            public const string CyanConcrete = "minecraft:concrete";
            public const string PurpleConcrete = "minecraft:concrete";
            public const string BlueConcrete = "minecraft:concrete";
            public const string BrownConcrete = "minecraft:concrete";
            public const string GreenConcrete = "minecraft:concrete";
            public const string RedConcrete = "minecraft:concrete";
            public const string BlackConcrete = "minecraft:concrete";
            public const string WhiteConcretePowder = "minecraft:concretepowder";
            public const string OrangeConcretePowder = "minecraft:concretepowder";
            public const string MagentaConcretePowder = "minecraft:concretepowder";
            public const string LightBlueConcretePowder = "minecraft:concretepowder";
            public const string YellowConcretePowder = "minecraft:concretepowder";
            public const string LimeConcretePowder = "minecraft:concretepowder";
            public const string PinkConcretePowder = "minecraft:concretepowder";
            public const string GrayConcretePowder = "minecraft:concretepowder";
            public const string LightGrayConcretePowder = "minecraft:concretepowder";
            public const string CyanConcretePowder = "minecraft:concretepowder";
            public const string PurpleConcretePowder = "minecraft:concretepowder";
            public const string BlueConcretePowder = "minecraft:concretepowder";
            public const string BrownConcretePowder = "minecraft:concretepowder";
            public const string GreenConcretePowder = "minecraft:concretepowder";
            public const string RedConcretePowder = "minecraft:concretepowder";
            public const string BlackConcretePowder = "minecraft:concretepowder";
            public const string Conduit = "minecraft:conduit";
            public const string Steak = "minecraft:cooked_beef";
            public const string CookedChicken = "minecraft:cooked_chicken";
            public const string CookedCod = "minecraft:cooked_cod";
            public const string CookedMutton = "minecraft:cooked_mutton";
            public const string CookedPorkchop = "minecraft:cooked_pork";
            public const string CookedRabbit = "minecraft:cooked_rabbit";
            public const string CookedSalmon = "minecraft:cooked_salmon";
            public const string Cookie = "minecraft:cookie";
            public const string TubeCoral = "minecraft:coral";
            public const string BrainCoral = "minecraft:coral";
            public const string BubbleCoral = "minecraft:coral";
            public const string FireCoral = "minecraft:coral";
            public const string HornCoral = "minecraft:coral";
            public const string TubeCoralBlock = "minecraft:coral_block";
            public const string BrainCoralBlock = "minecraft:coral_block";
            public const string BubbleCoralBlock = "minecraft:coral_block";
            public const string FireCoralBlock = "minecraft:coral_block";
            public const string HornCoralBlock = "minecraft:coral_block";
            public const string DeadTubeCoralBlock = "minecraft:coral_block";
            public const string DeadBrainCoralBlock = "minecraft:coral_block";
            public const string DeadBubbleCoralBlock = "minecraft:coral_block";
            public const string DeadFireCoralBlock = "minecraft:coral_block";
            public const string DeadHornCoralBlock = "minecraft:coral_block";
            public const string TubeCoralFan = "minecraft:coral_fan";
            public const string BrainCoralFan = "minecraft:coral_fan";
            public const string BubbleCoralFan = "minecraft:coral_fan";
            public const string FireCoralFan = "minecraft:coral_fan";
            public const string HornCoralFan = "minecraft:coral_fan";
            public const string DeadTubeCoralFan = "minecraft:coral_fan_dead";
            public const string DeadBrainCoralFan = "minecraft:coral_fan_dead";
            public const string DeadBubbleCoralFan = "minecraft:coral_fan_dead";
            public const string DeadFireCoralFan = "minecraft:coral_fan_dead";
            public const string DeadHornCoralFan = "minecraft:coral_fan_dead";
            public const string CowSpawnEgg = "minecraft:cow_spawn_egg";
            public const string CrackedNetherBricks = "minecraft:cracked_nether_bricks";
            public const string CrackedPolishedBlackstoneBricks = "minecraft:cracked_polished_blackstone_bricks";
            public const string CraftingTable = "minecraft:crafting_table";
            public const string CreeperChargeBannerPattern = "minecraft:creeper_banner_pattern";
            public const string CreeperSpawnEgg = "minecraft:creeper_spawn_egg";
            public const string CrimsonButton = "minecraft:crimson_button";
            public const string CrimsonDoor = "minecraft:crimson_door";
            public const string CrimsonFence = "minecraft:crimson_fence";
            public const string CrimsonFenceGate = "minecraft:crimson_fence_gate";
            public const string CrimsonFungus = "minecraft:crimson_fungus";
            public const string CrimsonHyphae = "minecraft:crimson_hyphae";
            public const string CrimsonNylium = "minecraft:crimson_nylium";
            public const string CrimsonPlanks = "minecraft:crimson_planks";
            public const string CrimsonPressurePlate = "minecraft:crimson_pressure_plate";
            public const string CrimsonRoots = "minecraft:crimson_roots";
            public const string CrimsonSign = "minecraft:crimson_sign";
            public const string CrimsonSlab = "minecraft:crimson_slab";
            public const string CrimsonStairs = "minecraft:crimson_stairs";
            public const string CrimsonStem = "minecraft:crimson_stem";
            public const string CrimsonTrapdoor = "minecraft:crimson_trapdoor";
            public const string Crossbow = "minecraft:crossbow";
            public const string CryingObsidian = "minecraft:crying_obsidian";
            public const string CyanDye = "minecraft:cyan_dye";
            public const string CyanGlazedTerracotta = "minecraft:cyan_glazed_terracotta";
            public const string DarkOakBoat = "minecraft:dark_oak_boat";
            public const string DarkOakButton = "minecraft:dark_oak_button";
            public const string DarkOakDoor = "minecraft:dark_oak_door";
            public const string DarkOakFenceGate = "minecraft:dark_oak_fence_gate";
            public const string DarkOakPressurePlate = "minecraft:dark_oak_pressure_plate";
            public const string DarkOakSign = "minecraft:dark_oak_sign";
            public const string DarkOakStairs = "minecraft:dark_oak_stairs";
            public const string DarkOakTrapdoor = "minecraft:dark_oak_trapdoor";
            public const string DarkPrismarineStairs = "minecraft:dark_prismarine_stairs";
            public const string DaylightDetector = "minecraft:daylight_detector";
            public const string DeadBush = "minecraft:deadbush";
            public const string DenyBlock = "minecraft:deny";
            public const string DetectorRails = "minecraft:detector_rail";
            public const string Diamond = "minecraft:diamond";
            public const string DiamondAxe = "minecraft:diamond_axe";
            public const string BlockOfDiamond = "minecraft:diamond_block";
            public const string DiamondBoots = "minecraft:diamond_boots";
            public const string DiamondChestplate = "minecraft:diamond_chestplate";
            public const string DiamondHelmet = "minecraft:diamond_helmet";
            public const string DiamondHoe = "minecraft:diamond_hoe";
            public const string DiamondHorseArmor = "minecraft:diamond_horse_armor";
            public const string DiamondLeggings = "minecraft:diamond_leggings";
            public const string DiamondOre = "minecraft:diamond_ore";
            public const string DiamondPickaxe = "minecraft:diamond_pickaxe";
            public const string DiamondShovel = "minecraft:diamond_shovel";
            public const string DiamondSword = "minecraft:diamond_sword";
            public const string DioriteStairs = "minecraft:diorite_stairs";
            public const string Dirt = "minecraft:dirt";
            public const string CoarseDirt = "minecraft:dirt";
            public const string Dispenser = "minecraft:dispenser";
            public const string DolphinSpawnEgg = "minecraft:dolphin_spawn_egg";
            public const string DonkeySpawnEgg = "minecraft:donkey_spawn_egg";
            public const string Sunflower = "minecraft:double_plant";
            public const string Lilac = "minecraft:double_plant";
            public const string TallGrass = "minecraft:double_plant";
            public const string LargeFern = "minecraft:double_plant";
            public const string RoseBush = "minecraft:double_plant";
            public const string Peony = "minecraft:double_plant";
            public const string DragonsBreath = "minecraft:dragon_breath";
            public const string DragonEgg = "minecraft:dragon_egg";
            public const string DriedKelp = "minecraft:dried_kelp";
            public const string DriedKelpBlock = "minecraft:dried_kelp_block";
            public const string Dropper = "minecraft:dropper";
            public const string DrownedSpawnEgg = "minecraft:drowned_spawn_egg";
            public const string Egg = "minecraft:egg";
            public const string ElderGuardianSpawnEgg = "minecraft:elder_guardian_spawn_egg";
            public const string UnknownElement = "minecraft:element_0";
            public const string Hydrogen = "minecraft:element_1";
            public const string Neon = "minecraft:element_10";
            public const string Fermium = "minecraft:element_100";
            public const string Mendelevium = "minecraft:element_101";
            public const string Nobelium = "minecraft:element_102";
            public const string Lawrencium = "minecraft:element_103";
            public const string Rutherfordium = "minecraft:element_104";
            public const string Dubnium = "minecraft:element_105";
            public const string Seaborgium = "minecraft:element_106";
            public const string Bohrium = "minecraft:element_107";
            public const string Hassium = "minecraft:element_108";
            public const string Meitnerium = "minecraft:element_109";
            public const string Sodium = "minecraft:element_11";
            public const string Darmstadtium = "minecraft:element_110";
            public const string Roentgenium = "minecraft:element_111";
            public const string Copernicium = "minecraft:element_112";
            public const string Nihonium = "minecraft:element_113";
            public const string Flerovium = "minecraft:element_114";
            public const string Moscovium = "minecraft:element_115";
            public const string Livermorium = "minecraft:element_116";
            public const string Tennessine = "minecraft:element_117";
            public const string Oganesson = "minecraft:element_118";
            public const string Magnesium = "minecraft:element_12";
            public const string Aluminum = "minecraft:element_13";
            public const string Silicon = "minecraft:element_14";
            public const string Phosphorus = "minecraft:element_15";
            public const string Sulphur = "minecraft:element_16";
            public const string Chlorine = "minecraft:element_17";
            public const string Argon = "minecraft:element_18";
            public const string Potassium = "minecraft:element_19";
            public const string Helium = "minecraft:element_2";
            public const string Calcium = "minecraft:element_20";
            public const string Scandium = "minecraft:element_21";
            public const string Titanium = "minecraft:element_22";
            public const string Vanadium = "minecraft:element_23";
            public const string Chromium = "minecraft:element_24";
            public const string Manganese = "minecraft:element_25";
            public const string Iron = "minecraft:element_26";
            public const string Cobalt = "minecraft:element_27";
            public const string Nickel = "minecraft:element_28";
            public const string Copper = "minecraft:element_29";
            public const string Lithium = "minecraft:element_3";
            public const string Zinc = "minecraft:element_30";
            public const string Gallium = "minecraft:element_31";
            public const string Germanium = "minecraft:element_32";
            public const string Arsenic = "minecraft:element_33";
            public const string Selenium = "minecraft:element_34";
            public const string Bromine = "minecraft:element_35";
            public const string Krypton = "minecraft:element_36";
            public const string Rubidium = "minecraft:element_37";
            public const string Strontium = "minecraft:element_38";
            public const string Yttrium = "minecraft:element_39";
            public const string Beryllium = "minecraft:element_4";
            public const string Zirconium = "minecraft:element_40";
            public const string Niobium = "minecraft:element_41";
            public const string Molybdenum = "minecraft:element_42";
            public const string Technetium = "minecraft:element_43";
            public const string Ruthenium = "minecraft:element_44";
            public const string Rhodium = "minecraft:element_45";
            public const string Palladium = "minecraft:element_46";
            public const string Silver = "minecraft:element_47";
            public const string Cadmium = "minecraft:element_48";
            public const string Indium = "minecraft:element_49";
            public const string Boron = "minecraft:element_5";
            public const string Tin = "minecraft:element_50";
            public const string Antimony = "minecraft:element_51";
            public const string Tellurium = "minecraft:element_52";
            public const string Iodine = "minecraft:element_53";
            public const string Xenon = "minecraft:element_54";
            public const string Cesium = "minecraft:element_55";
            public const string Barium = "minecraft:element_56";
            public const string Lanthanum = "minecraft:element_57";
            public const string Cerium = "minecraft:element_58";
            public const string Praseodymium = "minecraft:element_59";
            public const string Carbon = "minecraft:element_6";
            public const string Neodymium = "minecraft:element_60";
            public const string Promethium = "minecraft:element_61";
            public const string Samarium = "minecraft:element_62";
            public const string Europium = "minecraft:element_63";
            public const string Gadolinium = "minecraft:element_64";
            public const string Terbium = "minecraft:element_65";
            public const string Dysprosium = "minecraft:element_66";
            public const string Holmium = "minecraft:element_67";
            public const string Erbium = "minecraft:element_68";
            public const string Thulium = "minecraft:element_69";
            public const string Nitrogen = "minecraft:element_7";
            public const string Ytterbium = "minecraft:element_70";
            public const string Lutetium = "minecraft:element_71";
            public const string Hafnium = "minecraft:element_72";
            public const string Tantalum = "minecraft:element_73";
            public const string Tungsten = "minecraft:element_74";
            public const string Rhenium = "minecraft:element_75";
            public const string Osmium = "minecraft:element_76";
            public const string Iridium = "minecraft:element_77";
            public const string Platinum = "minecraft:element_78";
            public const string Gold = "minecraft:element_79";
            public const string Oxygen = "minecraft:element_8";
            public const string Mercury = "minecraft:element_80";
            public const string Thallium = "minecraft:element_81";
            public const string Lead = "minecraft:element_82";
            public const string Bismuth = "minecraft:element_83";
            public const string Polonium = "minecraft:element_84";
            public const string Astatine = "minecraft:element_85";
            public const string Radon = "minecraft:element_86";
            public const string Francium = "minecraft:element_87";
            public const string Radium = "minecraft:element_88";
            public const string Actinium = "minecraft:element_89";
            public const string Fluorine = "minecraft:element_9";
            public const string Thorium = "minecraft:element_90";
            public const string Protactinium = "minecraft:element_91";
            public const string Uranium = "minecraft:element_92";
            public const string Neptunium = "minecraft:element_93";
            public const string Plutonium = "minecraft:element_94";
            public const string Americium = "minecraft:element_95";
            public const string Curium = "minecraft:element_96";
            public const string Berkelium = "minecraft:element_97";
            public const string Californium = "minecraft:element_98";
            public const string Einsteinium = "minecraft:element_99";
            public const string Elytra = "minecraft:elytra";
            public const string Emerald = "minecraft:emerald";
            public const string BlockOfEmerald = "minecraft:emerald_block";
            public const string EmeraldOre = "minecraft:emerald_ore";
            public const string Map = "minecraft:empty_map";
            public const string EnchantedBook = "minecraft:enchanted_book";
            public const string EnchantedGoldenApple = "minecraft:enchanted_golden_apple";
            public const string EnchantingTable = "minecraft:enchanting_table";
            public const string EndStoneBrickStairs = "minecraft:end_brick_stairs";
            public const string EndStoneBricks = "minecraft:end_bricks";
            public const string EndCrystal = "minecraft:end_crystal";
            public const string EndPortalFrame = "minecraft:end_portal_frame";
            public const string EndRod = "minecraft:end_rod";
            public const string EndStone = "minecraft:end_stone";
            public const string EnderChest = "minecraft:ender_chest";
            public const string EyeOfEnder = "minecraft:ender_eye";
            public const string EnderPearl = "minecraft:ender_pearl";
            public const string EndermanSpawnEgg = "minecraft:enderman_spawn_egg";
            public const string EndermiteSpawnEgg = "minecraft:endermite_spawn_egg";
            public const string EvokerSpawnEgg = "minecraft:evoker_spawn_egg";
            public const string BottleOEnchanting = "minecraft:experience_bottle";
            public const string Feather = "minecraft:feather";
            public const string OakFence = "minecraft:fence";
            public const string SpruceFence = "minecraft:fence";
            public const string BirchFence = "minecraft:fence";
            public const string JungleFence = "minecraft:fence";
            public const string AcaciaFence = "minecraft:fence";
            public const string DarkOakFence = "minecraft:fence";
            public const string OakFenceGate = "minecraft:fence_gate";
            public const string FermentedSpiderEye = "minecraft:fermented_spider_eye";
            public const string FieldMasonedBannerPattern = "minecraft:field_masoned_banner_pattern";
            public const string FireCharge = "minecraft:fire_charge";
            public const string FireworkRocket = "minecraft:firework_rocket";
            public const string FireworkStar = "minecraft:firework_star";
            public const string FishingRod = "minecraft:fishing_rod";
            public const string FletchingTable = "minecraft:fletching_table";
            public const string Flint = "minecraft:flint";
            public const string FlintAndSteel = "minecraft:flint_and_steel";
            public const string FlowerChargeBannerPattern = "minecraft:flower_banner_pattern";
            public const string FlowerPot = "minecraft:flower_pot";
            public const string FoxSpawnEgg = "minecraft:fox_spawn_egg";
            public const string ItemFrame = "minecraft:frame";
            public const string Furnace = "minecraft:furnace";
            public const string GhastSpawnEgg = "minecraft:ghast_spawn_egg";
            public const string GhastTear = "minecraft:ghast_tear";
            public const string GildedBlackstone = "minecraft:gilded_blackstone";
            public const string Glass = "minecraft:glass";
            public const string GlassBottle = "minecraft:glass_bottle";
            public const string GlassPane = "minecraft:glass_pane";
            public const string GlisteringMelonSlice = "minecraft:glistering_melon_slice";
            public const string GlobeBannerPattern = "minecraft:globe_banner_pattern";
            public const string GlowBerries = "minecraft:glow_berries";
            public const string GlowInkSac = "minecraft:glow_ink_sac";
            public const string GlowItemFrame = "minecraft:glow_item_frame";
            public const string GlowLichen = "minecraft:glow_lichen";
            public const string GlowSquidSpawnEgg = "minecraft:glow_squid_spawn_egg";
            public const string Glowstone = "minecraft:glowstone";
            public const string GlowstoneDust = "minecraft:glowstone_dust";
            public const string GoatHorn = "minecraft:goat_horn";
            public const string GoatSpawnEgg = "minecraft:goat_spawn_egg";
            public const string GoldIngot = "minecraft:gold_ingot";
            public const string GoldNugget = "minecraft:gold_nugget";
            public const string GoldOre = "minecraft:gold_ore";
            public const string GoldenApple = "minecraft:golden_apple";
            public const string GoldenAxe = "minecraft:golden_axe";
            public const string GoldenBoots = "minecraft:golden_boots";
            public const string GoldenCarrot = "minecraft:golden_carrot";
            public const string GoldenChestplate = "minecraft:golden_chestplate";
            public const string GoldenHelmet = "minecraft:golden_helmet";
            public const string GoldenHoe = "minecraft:golden_hoe";
            public const string GoldenHorseArmor = "minecraft:golden_horse_armor";
            public const string GoldenLeggings = "minecraft:golden_leggings";
            public const string GoldenPickaxe = "minecraft:golden_pickaxe";
            public const string GoldenShovel = "minecraft:golden_shovel";
            public const string GoldenSword = "minecraft:golden_sword";
            public const string Granite = "minecraft:granite";
            public const string GraniteSlab = "minecraft:granite_slab";
            public const string GraniteStairs = "minecraft:granite_stairs";
            public const string Grass = "minecraft:grass";
            public const string GrassBlock = "minecraft:grass_block";
            public const string GrassPath = "minecraft:grass_path";
            public const string Gravel = "minecraft:gravel";
            public const string GrayBanner = "minecraft:gray_banner";
            public const string GrayCandle = "minecraft:gray_candle";
            public const string GrayCandleCake = "minecraft:gray_candle_cake";
            public const string GrayDye = "minecraft:gray_dye";
            public const string GrayGlazedTerracotta = "minecraft:gray_glazed_terracotta";
            public const string GrayShulkerBox = "minecraft:gray_shulker_box";
            public const string GrayStainedGlass = "minecraft:gray_stained_glass";
            public const string GrayStainedGlassPane = "minecraft:gray_stained_glass_pane";
            public const string GrayTerracotta = "minecraft:gray_terracotta";
            public const string GrayWool = "minecraft:gray_wool";
            public const string GreenBanner = "minecraft:green_banner";
            public const string GreenCandle = "minecraft:green_candle";
            public const string GreenCandleCake = "minecraft:green_candle_cake";
            public const string GreenDye = "minecraft:green_dye";
            public const string GreenGlazedTerracotta = "minecraft:green_glazed_terracotta";
            public const string GreenShulkerBox = "minecraft:green_shulker_box";
            public const string GreenStainedGlass = "minecraft:green_stained_glass";
            public const string GreenStainedGlassPane = "minecraft:green_stained_glass_pane";
            public const string GreenTerracotta = "minecraft:green_terracotta";
            public const string GreenWool = "minecraft:green_wool";
            public const string GuardianSpawnEgg = "minecraft:guardian_spawn_egg";
            public const string Gunpowder = "minecraft:gunpowder";
            public const string Terracotta = "minecraft:hardened_clay";
            public const string HayBale = "minecraft:hay_block";
            public const string HeartOfTheSea = "minecraft:heart_of_the_sea";
            public const string HeavyWeightedPressurePlate = "minecraft:heavy_weighted_pressure_plate";
            public const string HoglinSpawnEgg = "minecraft:hoglin_spawn_egg";
            public const string HoneyBlock = "minecraft:honey_block";
            public const string HoneyBottle = "minecraft:honey_bottle";
            public const string Honeycomb = "minecraft:honeycomb";
            public const string HoneycombBlock = "minecraft:honeycomb_block";
            public const string Hopper = "minecraft:hopper";
            public const string MinecartWithHopper = "minecraft:hopper_minecart";
            public const string HorseSpawnEgg = "minecraft:horse_spawn_egg";
            public const string HuskSpawnEgg = "minecraft:husk_spawn_egg";
            public const string Ice = "minecraft:ice";
            public const string InkSac = "minecraft:ink_sac";
            public const string IronAxe = "minecraft:iron_axe";
            public const string IronBars = "minecraft:iron_bars";
            public const string BlockOfIron = "minecraft:iron_block";
            public const string IronBoots = "minecraft:iron_boots";
            public const string IronChestplate = "minecraft:iron_chestplate";
        }
    }

    

}
