<script setup>
import { EllipsisVerticalIcon } from '@heroicons/vue/20/solid'
import { ArrowDownIcon, ArrowUpIcon } from '@heroicons/vue/20/solid'

const projects = [
  { name: 'Graph API', initials: 'GA', href: '#', members: 16, bgColor: 'bg-pink-600' },
  { name: 'Component Design', initials: 'CD', href: '#', members: 12, bgColor: 'bg-purple-600' },
  { name: 'Templates', initials: 'T', href: '#', members: 16, bgColor: 'bg-yellow-500' },
  { name: 'React Components', initials: 'RC', href: '#', members: 8, bgColor: 'bg-green-500' },
  { name: 'React Components', initials: 'RC', href: '#', members: 8, bgColor: 'bg-green-500' },
]





const stats = [
  { name: 'Total Subscribers', stat: '71,897' },
  { name: 'Avg. Open Rate', stat: '58.16%' },
  { name: 'Avg. Click Rate', stat: '24.57%' },
  { name: 'Avg. Click Rate', stat: '24.57%' },
  { name: 'Avg. Click Rate', stat: '24.57%' },
  { name: 'Avg. Click Rate', stat: '24.57%' },
]
</script>


<template>
    <div class="py-10">
      <header>
        <div class="mx-auto max-w-3xl lg:max-w-7xl px-4 sm:px-6 lg:px-8">
          <h1 class="text-3xl font-bold leading-tight tracking-tight text-gray-900">Dashboard</h1>
        </div>
      </header>
      <main>
        <div class="mx-auto max-w-3xl lg:max-w-7xl sm:px-6 lg:px-8">
          
          <!-- Content -->
          <div class="px-4 py-8 sm:px-0">

            <div>
                <h2 class="text-base font-semibold leading-6 text-gray-900">Heighest Ranking Employers</h2>
                <ul role="list" class="mt-3 grid grid-cols-1 gap-5 sm:grid-cols-2 sm:gap-6 lg:grid-cols-3">
                <li v-for="project in projects" :key="project.name" class="col-span-1 flex rounded-md shadow-sm">
                    <div :class="[project.bgColor, 'flex w-16 flex-shrink-0 items-center justify-center rounded-l-md text-sm font-medium text-white']">{{ project.initials }}</div>
                    <div class="flex flex-1 items-center justify-between truncate rounded-r-md border-b border-r border-t border-gray-200 bg-white">
                    <div class="flex-1 truncate px-4 py-2 text-sm">
                        <a :href="project.href" class="font-medium text-gray-900 hover:text-gray-600">{{ project.name }}</a>
                        <p class="text-gray-500">{{ project.members }} Members</p>
                    </div>
                    
                    </div>
                </li>
                </ul>
            </div>
          </div>


          <div class="px-4 py-8 sm:px-0">
            <div>
                <h2 class="text-base font-semibold leading-6 text-gray-900">Lowest Ranking Employers</h2>
                <ul role="list" class="mt-3 grid grid-cols-1 gap-5 sm:grid-cols-2 sm:gap-6 lg:grid-cols-3">
                <li v-for="project in projects" :key="project.name" class="col-span-1 flex rounded-md shadow-sm">
                    <div :class="[project.bgColor, 'flex w-16 flex-shrink-0 items-center justify-center rounded-l-md text-sm font-medium text-white']">{{ project.initials }}</div>
                    <div class="flex flex-1 items-center justify-between truncate rounded-r-md border-b border-r border-t border-gray-200 bg-white">
                    <div class="flex-1 truncate px-4 py-2 text-sm">
                        <a :href="project.href" class="font-medium text-gray-900 hover:text-gray-600">{{ project.name }}</a>
                        <p class="text-gray-500">{{ project.members }} Members</p>
                    </div>
                    
                    </div>
                </li>
                </ul>
            </div>
          </div>
          <!-- /End Content -->
          
        </div>
      </main>
    </div>
  </template>