import {
  Bookmark,
  Command,
  Facebook,
  Figma,
  Heart,
  Instagram,
  Linkedin,
  LogIn,
  MailPlus,
  MessageSquare,
  Pencil,
  ThumbsUp,
  UserPlus,
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
}

export function AppIcon() {
  return (
    <svg
      xmlns="http://www.w3.org/2000/svg"
      width="35"
      height="30"
      className="text-accent-foreground"
    >
      <path
        fill="#13aff0"
        fillRule="evenodd"
        d="M35 24.354c0-.704-.208-1.36-.565-1.91L22.937 2.525A3.536 3.536 0 0 0 19.813.652h-6.077l17.76 30.666 2.8-4.833c.553-.925.704-1.334.704-2.131Zm-35-.037 2.956 5.093h.001a3.536 3.536 0 0 0 3.157 1.938h19.624l-4.072-7.03H0ZM10.832 5.621l7.938 13.701H2.893l7.939-13.701Z"
        clipRule="evenodd"
      />
    </svg>
  )
}
