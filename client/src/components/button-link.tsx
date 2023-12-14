import Link from "next/link"
import { cn } from "@/libs/utils"

import { Icons } from "./icons"

interface ButtonLinkProps
  extends React.AnchorHTMLAttributes<HTMLAnchorElement> {
  href: string
  variant?: "primary" | "secondary"
  children: React.ReactNode
  icon?: keyof typeof Icons
  classIcon?: string
}

export function ButtonLink({
  href,
  children,
  variant = "primary",
  icon,
  className,
  classIcon,
}: ButtonLinkProps) {
  const Icon = Icons[icon || "command"]
  return (
    <Link
      href={href}
      className={cn(
        className,
        `text-foreground  flex items-center gap-2 rounded-lg py-[10px] text-[13px] leading-3`,
        variant === "primary" &&
          "bg-accent text-accent-foreground hover:bg-accent-hover font-semibold transition-all",
        variant === "secondary" &&
          "bg-muted text-muted-foreground hover:bg-muted-hover font-medium transition-all"
      )}
    >
      {icon && <Icon className={cn(classIcon, "h-4 w-4")} />}
      <span>{children}</span>
    </Link>
  )
}
