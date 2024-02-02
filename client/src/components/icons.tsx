import {
  AlertTriangle,
  ArrowUp,
  Bookmark,
  Command,
  Facebook,
  Figma,
  Heart,
  Image,
  ImageMinus,
  Instagram,
  Linkedin,
  LogIn,
  MailPlus,
  MessageSquare,
  Pencil,
  Rocket,
  ThumbsUp,
  Upload,
  UserPlus,
  X,
  Youtube,
  type IconNode as LucideIcon,
} from "lucide-react"

export type Icon = LucideIcon

export const Icons = {
  logIn: LogIn,
  command: Command,
  pencil: Pencil,
  thumbsUp: ThumbsUp,
  bookmark: Bookmark,
  heart: Heart,
  messageSquare: MessageSquare,
  userPlus: UserPlus,
  mailPlus: MailPlus,
  facebook: Facebook,
  instagram: Instagram,
  linkedin: Linkedin,
  figma: Figma,
  youtube: Youtube,
  upload: Upload,
  rocket: Rocket,
  image: Image,
  arrowUp: ArrowUp,
  close: X,
  imageMinus: ImageMinus,
  alertTriangle: AlertTriangle,
}

export function AppIcon() {
  return (
    <svg xmlns="http://www.w3.org/2000/svg" width="35" height="31">
      <path
        fill="#13aff0"
        d="M35 24.35c0-.7-.2-1.36-.56-1.9L22.94 2.51A3.54 3.54 0 0 0 19.8.65h-6.07L31.5 31.32l2.8-4.83c.55-.93.7-1.34.7-2.14Zm-35-.03 2.96 5.09a3.54 3.54 0 0 0 3.15 1.94h19.63l-4.07-7.03H0Zm10.83-18.7 7.94 13.7H2.89l7.94-13.7Z"
        transform="scale(0.85)"
      />
    </svg>
  )
}

export function Spiner() {
  return (
    <svg
      className="-ml-1 mr-3 h-5 w-5 animate-spin text-white motion-reduce:hidden"
      xmlns="http://www.w3.org/2000/svg"
      fill="none"
      viewBox="0 0 24 24"
    >
      <circle
        className="opacity-25"
        cx="12"
        cy="12"
        r="10"
        stroke="currentColor"
        strokeWidth="4"
      ></circle>
      <path
        className="opacity-75"
        fill="currentColor"
        d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"
      ></path>
    </svg>
  )
}
