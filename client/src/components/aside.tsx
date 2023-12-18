interface AsideCreatorProps {
  children: React.ReactNode
}

export function Aside({ children }: AsideCreatorProps) {
  return (
    <aside className="no-scroll sticky inset-y-0 right-0 top-16 flex h-[calc(100vh-4rem)] w-[440px] flex-col gap-8 overflow-y-scroll pb-4">
      {children}
    </aside>
  )
}
