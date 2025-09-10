using Qud.API;
using System;
using System.Collections.Generic;
using System.Linq;
using XRL.World.Anatomy;
using XRL.World.Effects;
using XRL.World.Parts.Mutation;
using XRL.UI;
using XRL.Rules;

namespace XRL.World.Conversations.Parts
{
    public class WaterRitualMAFT_LiveAndDrink : IConversationPart
    {
        public static List<string> highlyEntropicVerbs = new List<string>() 
        { 
            "jam", "sin", "run", "jump", "pulse", "ebb", "flow", "vibe", "shatter",
            "smash", "grab", "hack", "slash", "flub", "bodge", "melt", "shimmer",
            "shine", "weep", "mumble", "live", "drink", "eat", "gulp", "burn",
            "smite", "smoulder", "spiral", "flicker", "crouch", "squat", "tear",
            "make", "break", "wander", "open", "close", "speak", "clamp", "soar",
            "fall", "coil", "slip", "slither", "be", "clip", "flicker", "alter",
            "change", "unlive", "undrink", "swap", "spit", "flatten", "fold",
            "pierce", "group", "end", "begin", "shoot", "freeze", "drip", "dribble",
            "fathom", "glitch", "stutter", "swish", "sit", "sleep", "dream",
            "crungle", "uncrungle", "exist", "cease", "erupt", "drag", "hook",
            "munch", "collect", "disperse", "dissolve", "refract", "reflect",
            "diffract", "diffuse", "pool", "warm", "cool", "seek", "find","spark",
            "charge", "lase", "scope", "act", "factor", "multiply", "divide",
            "conquer", "subtract", "add", "power", "tetrate", "sublimate", "walk",
            "sort", "search", "merge", "quicken", "taste", "square", "cube",
            "operate", "perform", "return", "pass", "parse", "interpret", "compile",
            "fragment", "defragment", "crystallize", "involute", "angle", "rise",
            "ascend", "descend", "climb", "grow", "shrink", "watch", "play", "work",
            "sharpen", "dull", "escape", "surpass", "gain", "differ", "form",
            "function", "expand", "collapse", "give", "fuzz", "slide", "force",
            "read", "write", "compose", "decompose", "talk", "share", "stay", "go",
            "evaluate", "think", "thrive", "shrive", "blink", "tabulate", "delve",
            "subduct", "induct", "conflate", "ablate", "erode", "erase", "evade",
            "avoid", "inure", "endure", "fade", "date", "time", "space", "un-vibe",
            "revert", "loop", "do while", "continue", "peck", "sample", "pick",
            "test", "split", "print", "log", "debug", "bug", "standardize", "deviate",
            "recrungle", "superpose", "entangle", "jitter", "quantize", "efface",
            "decrungle", "move", "reel", "spool", "leap", "go to", "go forth",
            "integrate", "derive", "maximize", "minimize", "optimize", "deoptimize",
            "consume", "produce", "convolve", "pile", "stack", "heap", "queue", "list",
            "link", "equate", "breach", "lap", "shiver", "undulate", "idle", "parallelize",
            "compute", "shade", "wink", "brighten", "fix", "repair", "source",
            "encrypt", "sap", "fill", "harvest", "plant", "click", "send", "put", "patch",
            "note", "inscribe", "keep", "shame", "berate", "suffer", "pack", "mistake",
            "sew", "bowl", "plate", "arrange", "array", "try", "except", "catch",
            "complicate", "glisten", "heighten", "deify", "worship", "flit", "bite",
            "redden", "shift", "perpetrate", "commit", "fork", "hang", "hang out",
            "wait", "divert", "compound", "obliterate", "sweeten", "cook", "be good",
            "be something", "be anything", "sit there", "do nothing", "be entropic",
            "stitch", "teleport", "siphon", "mediate", "meditate", "explore", "lose",
            "win", "cycle", "recycle", "upgrade", "practice", "deflect", "spew", "huff",
            "puff", "pickle", "shelve", "stub", "darken", "brighten", "strobe", "grind",
            "stab", "cut", "hew", "seal", "pose", "wriggle", "be inscrutable", "poke",
            "fling", "quit", "save", "serialize", "batter", "extend", "retract",
            "mirror", "skip", "append", "randomize", "re-seed", "retrieve", "propagate",
            "display", "crush", "bug out", "phase", "un-phase", "decarbonize", "puppet",
            "preclude", "exclude", "handle", "brace", "bracket", "affect", "correct",
            "ward", "fight", "smoke", "surge", "lie", "chatter", "want", "glitter",
            "stun", "confuse", "defoliate", "demand", "listen", "sprint", "toddle",
            "coddle", "muddle", "mix", "stalk", "tinker", "touch", "smell", "sniff",
            "hear", "fear", "beware", "falsify", "indict", "document", "copy", "paste",
            "zoom in", "zoom out", "consider", "rewrite", "choose", "arbitrate", "stink",
            "survive", "prevent", "query", "structure", "monitor", "delight", "cavort",
            "seethe", "cope", "pour", "dispatch", "snack", "chug", "shadow", "whisper",
            "sip", "steam", "teem", "throttle", "irradicate", "eradicate", "enclose",
            "look up", "look down", "look around", "gossip", "sequester", "separate",
            "lift", "synthesize", "spy", "soil", "spoil", "oil", "grease", "ring",
            "trace", "retrace", "track", "farm", "tumble", "sound off", "roll", "count",
            "gush", "ooze", "emit", "fulfil", "demonstrate", "quest", "teach", "study",
            "bother", "unfold", "unleash", "overflow", "breathe", "inhale", "exhale",
            "procreate", "profane", "devour", "perfume", "signal", "bend", "lapse",
            "glance", "glaze", "rectify", "picture", "paint", "type", "cast", "foaminate",
            "swing", "dangle", "wangle", "pinch", "bound", "border", "manufacture", "chat",
            "quaff", "gorge", "nibble", "gnaw", "subsume", "broil", "bake", "fry", 
            "identify", "select", "deselect", "naturalize", "inherit", "morph", "hum",
            "preach", "sing", "praise", "idolize", "be worshipped", "lick", "slow down",
            "rewind", "pause", "shut down", "log off", "desecrate", "graft", "drone",
            "order", "dequeue", "wrap", "implement", "implant", "elaborate", "embrace",
            "verify", "program", "combine", "reduce", "originate", "categorize", "unify",
            "format", "fail", "seem", "betray", "bind", "contextualize", "equivocate", "kiss",
            "tell", "love", "leave", "burst", "underflow", "compensate", "splatter", "remain",
            "simulate", "vitrify", "bounce", "pounce", "trounce", "radiate", "refactor"
        };

        public bool sibPrefix = false;

        public override bool WantEvent(int ID, int Propagation) => base.WantEvent(ID, Propagation) || ID == DisplayTextEvent.ID || ID == GetChoiceTagEvent.ID;

        public override bool HandleEvent(DisplayTextEvent E) {
            if (The.Speaker.GetWaterRitualLiquid(The.Player) == "warmstatic") {
                string displayText = E.Text.ToString();
                string[] splitSoFar = displayText.Split("Live and drink");
                if (splitSoFar.Count() != 2)
                {
                    return base.HandleEvent(E);
                }

                string live = WaterRitualMAFT_LiveAndDrink.highlyEntropicVerbs.GetRandomElement<string>((System.Random) null);
                string drink = WaterRitualMAFT_LiveAndDrink.highlyEntropicVerbs.GetRandomElement<string>((System.Random) null);
                string liveAndDrink = char.ToUpper(live[0]) + live.Substring(1) + " and " + drink;

                E.Text.Clear();
                E.Text.Append(splitSoFar[0]);
                E.Text.Append(liveAndDrink);
                E.Text.Append(splitSoFar[1]);
            }

            return base.HandleEvent(E);
        }
    }
}
