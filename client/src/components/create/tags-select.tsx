import { useEffect, useRef, useState } from "react"
import { cn } from "@/libs/utils"
import { ControllerRenderProps } from "react-hook-form"

import { FormSchema } from "@/components/forms/artwork-create-form"
import { Icons } from "@/components/icons"

interface TagsSelectProps
  extends Omit<ControllerRenderProps<FormSchema, "tags">, "ref"> {
  tags: string[]
}

export function TagsSelect({
  tags = [],
  onBlur,
  onChange,
  name,
  value,
}: TagsSelectProps) {
  const [query, setQuery] = useState<string>("")
  const [selected, setSelected] = useState<string[]>([])
  const [menuOpen, setMenuOpen] = useState<boolean>(false)

  const inputRef = useRef<HTMLInputElement>(null)

  const filteredTags = tags.filter(
    (tag) =>
      tag.toLocaleLowerCase().includes(query.toLocaleLowerCase().trim()) &&
      !selected.includes(tag)
  )

  useEffect(() => {
    onChange(selected)
  }, [selected, onChange])

  return (
    <div className="relative flex h-full w-full flex-col">
      <div
        className={cn(
          "bg-input border-input-border w-full rounded-md border-[1px] px-1 py-2",
          selected.length > 10 && "border-red-400"
        )}
      >
        <div className="flex flex-wrap gap-1 p-1 text-xs">
          {selected.map((tag) => {
            return (
              <div
                key={tag}
                className="bg-muted text-foreground 0 flex w-fit items-center gap-2
                rounded-md px-3 py-1.5"
              >
                {tag}
                <div
                  onMouseDown={(e) => e.preventDefault()}
                  onClick={() => setSelected(selected.filter((i) => i !== tag))}
                >
                  <Icons.close className="hover:text-accent h-[17px] w-[17px] cursor-pointer transition-all" />
                </div>
              </div>
            )
          })}

          <input
            ref={inputRef}
            type="text"
            value={query}
            onChange={(e) => setQuery(e.target.value.trimStart())}
            className={cn(
              "text-foreground bg-input p-1 text-[14px] focus:outline-none",
              selected.length <= 0 ? "w-full" : "w-auto"
            )}
            placeholder="Search tags"
            onFocus={() => setMenuOpen(true)}
            onBlur={() => setMenuOpen(false)}
          />
        </div>
      </div>

      <div
        className={cn(
          "flex w-full justify-center",
          menuOpen ? "blook" : "hidden"
        )}
      >
        <div
          className={cn(
            "no-scroll bg-muted absolute  mt-2 flex  w-full overflow-y-scroll rounded-md",
            filteredTags.length <= 2 ? "h-auto" : "h-[7.5rem]"
          )}
        >
          <ul className="w-full">
            {filteredTags?.length ? (
              filteredTags.map((tag, i) => (
                <li
                  key={tag}
                  className="hover:bg-accent-hover hover:text-accent-foreground w-full cursor-pointer rounded-md p-2 pl-4"
                  onMouseDown={(e) => e.preventDefault()}
                  onClick={() => {
                    setMenuOpen(true)
                    setSelected((prev) => [...prev, tag])
                    setQuery("")
                  }}
                >
                  {tag}
                </li>
              ))
            ) : (
              <li className="text-secondary-foreground h-full w-full p-2 text-center">
                No options available
              </li>
            )}
          </ul>
        </div>
      </div>
    </div>
  )
}
