interface TagItemProps {
  tag: string
}

export function TagItem({ tag }: TagItemProps) {
  return (
    <div className="bg-tag text-tag-foreground rounded-md px-2 py-[3px] text-[12px]">
      {tag}
    </div>
  )
}
